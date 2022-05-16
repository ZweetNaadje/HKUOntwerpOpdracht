using System;
using Pickup_Logic;
using Player_Handler;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PickUp_Logic
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private GameObject _lampGameObject;
        [SerializeField] private Player _player;

        public string PickupName;
        
        private void OnTriggerEnter(Collider other)
        {        
            var inventory = other.gameObject.GetComponent<Inventory>();

            if (inventory == null)
            {
                return;
            }
            
            FMODUnity.RuntimeManager.PlayOneShot("event:/PickUp", _player.transform.position);

            if (PickupName == "key")
            {
                inventory.key = true;
                inventory.AddKey();
            }

            if (PickupName == "key1")
            {
                inventory.key1 = true;
                inventory.AddKey();
            }

            if (PickupName == "key2")
            {
                inventory.key2 = true;
                inventory.AddKey();
            }

            if (PickupName == "spring")
            {
                inventory.hasSpring = true;
                inventory.DisplayToast("Press (SPACE) to jump!");
            }

            if (PickupName == "Portal Authorization Key")
            {
                inventory.hasPortalAuthorization = true;
                inventory.DisplayToast("You can now use the Teleport Pads!");
            }
            
            if (PickupName == "lamp")
            {
                inventory.hasLamp = true;
                inventory.DisplayToast("Press (F) to use your magic lamp!");
            }

            if (PickupName == "collectible")
            {
                inventory.AddCollectible();
                inventory.DisplayToast("You found a hidden collectible!");
            }
        
            Destroy(this.gameObject);
        }
    }
}
