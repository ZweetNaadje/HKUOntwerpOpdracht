using System;
using System.Collections.Generic;
using Pickup_Logic;
using Respawn_Logic;
using StarterAssets;
using UnityEngine;
using UnityEngine.VFX;

namespace Player_Handler
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private ThirdPersonController _thirdPersonController;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private RespawnBehaviour _respawnBehaviour;

        [SerializeField] private List<VisualEffect> _visualEffects = new List<VisualEffect>();

        public void StartBoosters()
        {
            foreach (var visualEffect in _visualEffects)
            {
                visualEffect.Play();
            }
        }

        public void StopBoosters()
        {
            foreach (var visualEffect in _visualEffects)
            {
                visualEffect.Stop();
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var respawnPoint = other.gameObject.GetComponent<RespawnPoint>();

            if (respawnPoint == null)
            {
                return;
            }
            
            _respawnBehaviour.SetRespawnPoint(respawnPoint);
        }

        private void Update()
        {
            if (transform.position.y < -20)
            {
                _respawnBehaviour.Respawn();
            }
        }
    }
}