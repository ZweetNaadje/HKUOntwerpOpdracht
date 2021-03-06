using Dissolver_Logic;
using Pickup_Logic;
using StarterAssets;
using UnityEngine;

namespace Unhide_Logic
{
    public class ToggleAbleLight : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private StarterAssetsInputs _starterAssets;
        [SerializeField] private Light _spotlight;
        [SerializeField] private Light _pointLight;
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
            _pointLight.enabled = _lampOn;
            
            // wanneer de lamp aan is,
            if (_lampOn == true)
            {
                RaycastHit hit;
                
                // schieten we een raycast,
                if (Physics.Raycast(_lampObject.position, _lampObject.forward, out hit, 10f))
                {
                    var other = hit.transform.gameObject;
                    
                    // als hetgeen wat we hitten de tag "SecretObject" heeft,
                    if (other.CompareTag("SecretObject"))
                    {
                        //var meshRenderer = other.GetComponent<MeshRenderer>();
                        var collider = other.GetComponent<Collider>();
                        var dissolveComponent = other.GetComponent<DissolveComponent>();
                        
                        // hetgeen wat we raken moet een MeshRenderer en Collider hebben.
                        if (collider == null || dissolveComponent == null)
                        {
                            return;
                        }

                        if (!dissolveComponent.IsHit)
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/SecretDoor", other.transform.position);
                        }
                        
                        // anonieme functie (zonder naam). Dissolve maar en als we klaar zijn,
                        dissolveComponent.StartDissolve(() =>
                        {
                            // dan zetten we de Collider uit.
                            collider.enabled = false;
                        });
                    }
                }
                    
                //Debug.DrawRay(_lampObject.position, rayDirection.direction * 20f, Color.white, float.MaxValue);
                Debug.DrawRay(_lampObject.position, _lampObject.transform.forward * 20f, Color.red);
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
