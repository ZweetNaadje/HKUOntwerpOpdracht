using StarterAssets;
using UnityEngine;

namespace Unhide_Logic
{
    public class UnhideMesh : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private StarterAssetsInputs _starterAssets;
        [SerializeField] private Light _spotlight;
        private bool _lampOn;
        
        // raycast afschieten voor max distance licht naar objects
        // alleen wanneer je rmb + f gebruikt
        // hide fake object (turn mesh renderer and collider off) Use tagssystem

        private void UseLamp()
        {
            if (_inventory.hasLamp && _starterAssets.aiming && _starterAssets.useLamp)
            {
               Debug.Log("hey dit werkt");
                // bool toggle
                _lampOn = !_lampOn;
            }
            _spotlight.enabled = _lampOn;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            _spotlight.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            UseLamp();
        }
    }
}
