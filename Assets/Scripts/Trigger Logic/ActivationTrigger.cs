using System;
using UnityEngine;

namespace Trigger_Logic
{
    public class ActivationTrigger : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public string TriggerName;
        public bool CanActivate;

        public void ActivateTrigger()
        {
            _animator.SetBool(TriggerName, true);
        }

        public void DeactivateTrigger()
        {
            _animator.SetBool(TriggerName, false);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (_animator == null || TriggerName.Length <= 0)  
            {
                return;
            }

            if (CanActivate)
            {
                ActivateTrigger();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_animator == null || TriggerName.Length <= 0)  
            {
                return;
            }
            
            DeactivateTrigger();
        }
    }
}
