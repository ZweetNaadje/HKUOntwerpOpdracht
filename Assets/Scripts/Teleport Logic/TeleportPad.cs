using UnityEngine;

namespace Teleport_Logic
{
    public class TeleportPad : MonoBehaviour
    {
        // Holds a reference to the destination teleport pad
        [SerializeField] private TeleportPad _destination;
        
        // Holds the time it takes to activate the teleporter
        [SerializeField] private float _activationTime;
        
        // Remembers if we just teleported in on the teleport pad
        private bool _didTeleport = false;
        
        // Remembers if we walked on the pad
        private bool _didActivate = false;
        
        // Holds the current time + activation time so we know when to teleport
        private float _activateTimer = 0.0f;
        
        /// <summary>
        /// Teleports the given component to its own position
        /// </summary>
        /// <param name="component">The transform we want to be teleported</param>
        private void Teleport(Transform component)
        {
            // Set the flag that we just teleported
            _didTeleport = true;
            
            // Set the position of the component to the teleporter position
            component.position = transform.position;
        }

        // When we enter a trigger
        private void OnTriggerEnter(Collider other)
        {
            // If we just teleported we dont want to do anything
            if (_didTeleport)
            {
                return;
            }
            
            // We stepped on a teleport pad we can set the teleporter active
            _didActivate = true;
            
            // Calculate the time when we should teleport
            _activateTimer = Time.time + _activationTime;
        }

        // We stay in a trigger
        private void OnTriggerStay(Collider other)
        {
            // If we stepped on a teleporter pad continue
            if (!_didActivate)
            {
                return;
            }
            
            // Check if the gameobject has a player script
            var player = other.gameObject.GetComponent<Player>();
        
            // Check if we have a valid player and a valid destination
            if (player == null || _destination == null)
            {
                return;
            }

            // If enough time has passed we teleport the player
            if (Time.time >= _activateTimer)
            {
                // Tell the destination teleporter to teleport the player towards him
                _destination.Teleport(player.transform);
            }
        }

        // When we exit a trigger
        private void OnTriggerExit(Collider other)
        {
            // Reset all the flags and timers
            _didTeleport = false;
            _didActivate = false;
            _activateTimer = 0.0f;
        }
    }
}