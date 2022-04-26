using Trigger_Logic;
using UnityEngine;

namespace Pickup_Logic
{
    public class DoorConfigurator : MonoBehaviour
    {
        [SerializeField] private ActivationTrigger _trigger;
        [SerializeField] private Inventory _inventory;
    
        
        // Update is called once per frame
        void Update()
        {
            // same as below
            /*if (_inventory.key && _inventory.key1 && _inventory.key2)
            {
                _trigger.CanActivate = true;
            }
            else
            {
                _trigger.CanActivate = false;
            }*/
            
            _trigger.CanActivate = _inventory.key && _inventory.key1 && _inventory.key2;
        }
    }
}
