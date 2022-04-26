using System;
using UnityEngine;

namespace Trigger_Logic
{
    public class ActivationTrigger : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public string TriggerName;
        public bool CanActivate;
        
        private void OnTriggerEnter(Collider other)
        {
            if (_animator == null || TriggerName.Length <= 0)  
            {
                return;
            }

            if (CanActivate)
            {
                _animator.SetBool(TriggerName, true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_animator == null || TriggerName.Length <= 0)  
            {
                return;
            }
            
            _animator.SetBool(TriggerName, false);
        }
    }
}
