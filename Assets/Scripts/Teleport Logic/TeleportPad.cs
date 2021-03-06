using Dissolver_Logic;
using Pickup_Logic;
using Player_Handler;
using UnityEngine;

namespace Teleport_Logic
{
    public class TeleportPad : MonoBehaviour
    {
        // Holds a reference to the destination teleport pad
        [SerializeField] private TeleportPad _destination;
        
        // Holds a reference to the inventory to see if we may use a teleportpad
        [SerializeField] private Inventory _inventory;
        
        // Holds the time it takes to activate the teleporter
        [SerializeField] private float _activationTime;
        
        // Remembers if we just teleported in on the teleport pad
        private bool _didTeleport = false;
      
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
            // If we just teleported or if we dont have a portal authorization we dont want to do anything
            if (_didTeleport || !_inventory.hasPortalAuthorization)
            {
                return;
            }
            
            // Check if the gameobject has a player script
            var player = other.gameObject.GetComponent<Player>();
            var dissolveComponent = other.gameObject.GetComponent<DissolveComponent>();
            
            // Check if we have a valid player and a valid destination
            if (player == null || _destination == null || dissolveComponent == null)
            {
                return;
            }
            
            FMODUnity.RuntimeManager.PlayOneShot("event:/Teleport", player.transform.position);
            
            player.StopBoosters();
            
            dissolveComponent.StartDissolve(() =>
            {
                _destination.Teleport(player.transform);
                
                player.StartBoosters();
                
                dissolveComponent.Reintegrate(() =>
                {
                    
                });
            });
        }

        // When we exit a trigger
        private void OnTriggerExit(Collider other)
        {
            // Reset all the flags and timers
            _didTeleport = false;
        }
    }
}