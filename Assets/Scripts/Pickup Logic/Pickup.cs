using Pickup_Logic;
using UnityEngine;

namespace PickUp_Logic
{
    public class Pickup : MonoBehaviour
    {
        public string PickupName;

        private void OnTriggerEnter(Collider other)
        {        
            var inventory = other.gameObject.GetComponent<Inventory>();

            if (inventory == null)
            {
                return;
            }

            if (PickupName == "key")
            {
                inventory.key = true;
            }

            if (PickupName == "key1")
            {
                inventory.key1 = true;
            }

            if (PickupName == "key2")
            {
                inventory.key2 = true;
            }

            if (PickupName == "spring")
            {
                inventory.hasSpring = true;
            }

            if (PickupName == "Portal Authorization Key")
            {
                inventory.hasPortalAuthorization = true;
            }
        
            Destroy(this.gameObject);
        }
    }
}
