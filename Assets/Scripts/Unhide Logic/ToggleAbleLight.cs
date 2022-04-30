using StarterAssets;
using UnityEngine;

namespace Unhide_Logic
{
    public class ToggleAbleLight : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private StarterAssetsInputs _starterAssets;
        [SerializeField] private Light _spotlight;
        [SerializeField] private Transform _lampObject;
        
        private bool _lampOn;
        
        // raycast afschieten voor max distance licht naar objects
        // alleen wanneer je rmb + f gebruikt
        // hide fake object (turn mesh renderer and collider off) Use tagssystem

        private void UseLamp()
        {
            // wanneer je de lamp hebt EN op F hebt gedrukt!
            if (_inventory.hasLamp &&  _starterAssets.useLamp)
            {
                // bool toggle
                _lampOn = !_lampOn;
            }
            
            _spotlight.enabled = _lampOn;
            
            // wanneer de lamp aan is,
            if (_lampOn == true)
            {
                RaycastHit hit;
                
                // schieten we een raycast,
                if (Physics.Raycast(_lampObject.position, _lampObject.up, out hit))
                {
                    var other = hit.transform.gameObject;
                    
                    // als hetgeen wat we hitten de tag "SecretObject" heeft,
                    if (other.CompareTag("SecretObject"))
                    {
                        var meshRenderer = other.GetComponent<MeshRenderer>();
                        var collider = other.GetComponent<Collider>();
                        
                        // hetgeen wat we raken moet een MeshRenderer en Collider hebben.
                        if (meshRenderer == null || collider == null)
                        {
                            return;
                        }
                        
                        // dan zetten we de MeshRenderer en Collider uit.
                        meshRenderer.enabled = false;
                        collider.enabled = false;
                        
                        Debug.Log("ik heb een secretwall geraakt");   
                    }
                }
                    
                //Debug.DrawRay(_lampObject.position, rayDirection.direction * 20f, Color.white, float.MaxValue);
                Debug.DrawRay(_lampObject.position, _lampObject.transform.up * 20f, Color.red);
            }
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
