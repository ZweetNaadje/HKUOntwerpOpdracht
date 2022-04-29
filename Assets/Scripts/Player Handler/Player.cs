using System;
using Respawn_Logic;
using StarterAssets;
using UnityEngine;

namespace Player_Handler
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private ThirdPersonController _thirdPersonController;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private RespawnBehaviour _respawnBehaviour;

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