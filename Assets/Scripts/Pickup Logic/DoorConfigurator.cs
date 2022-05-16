using System;
using Trigger_Logic;
using UnityEngine;

namespace Pickup_Logic
{
    public class DoorConfigurator : MonoBehaviour
    {
        [SerializeField] private ActivationTrigger _triggerDoorOne;
        [SerializeField] private ActivationTrigger _triggerDoorTwo;
        [SerializeField] private ActivationTrigger _triggerDoorThree;    
        [SerializeField] private Inventory _inventory;
        
        private void OnTriggerEnter(Collider other)
        {
            // Does other have an inventory?  
            // If yes, does the inventory have key, key1 and key2?
            // if yes rotate the door

            var inventory = other.gameObject.GetComponent<Inventory>();
            
            if (inventory == null)
            {
                return;
            }
            
            if (_inventory.key)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/FinalDoor", other.transform.position);
                _triggerDoorOne.ActivateTrigger();
            }
            
            if (_inventory.key1)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/FinalDoor", other.transform.position);
                _triggerDoorTwo.ActivateTrigger();
            }
            
            if (_inventory.key2)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/FinalDoor", other.transform.position);
                _triggerDoorThree.ActivateTrigger();
            }
        }
    }
}
