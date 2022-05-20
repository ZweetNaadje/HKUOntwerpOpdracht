using System;
using Pickup_Logic;
using Trigger_Logic;
using UnityEngine;

namespace Timing_Logic
{
    public class TimingDoor : MonoBehaviour
    {
        [SerializeField] private ActivationTrigger _trigger;
        
        // Doet de deur dicht na een set tijd
        [SerializeField] private float _closeDoorAfterSetTime;

        private bool _didTriggerPressurePlate = false;
        
        // Houdt de tijd bij die verstreken is sinds de ontriggerexit
        private float _timer = 0.0f;

        private void OnTriggerEnter(Collider other)
        {
            // Does other have an inventory?  
            // If yes, open the door
            // after X time close the door

            var inventory = other.gameObject.GetComponent<Inventory>();
            
            if (inventory == null)
            {
                return;
            }
            
            FMODUnity.RuntimeManager.PlayOneShot("event:/PressurePlates", other.transform.position);
            
            _trigger.ActivateTrigger();
        }

        private void OnTriggerExit(Collider other)
        {
            _timer = Time.time + _closeDoorAfterSetTime;
            _didTriggerPressurePlate = true;
        }


        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > _timer && _didTriggerPressurePlate)
            {
                _trigger.DeactivateTrigger();
                _didTriggerPressurePlate = false;
                
                // Zet _timer op 0.0 omdat je je tijd wilt resetten.
                // Beginwaarde is 0.0, hou die dan ook aan. Denk aan een stopwatch. 
                _timer = 0f;
            }
        }
    }
}
