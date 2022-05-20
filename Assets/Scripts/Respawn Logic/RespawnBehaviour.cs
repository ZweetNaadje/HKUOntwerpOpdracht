using Dissolver_Logic;
using Player_Handler;
using UnityEngine;

namespace Respawn_Logic
{
    public class RespawnBehaviour : MonoBehaviour
    {
        [SerializeField] private DissolveComponent _dissolveComponent;
        [SerializeField] private Player _player;
        
        private RespawnPoint _currentRespawnPoint;

        public void Respawn()
        {
            if (_currentRespawnPoint == null)
            {
                return;
            }
            
            _player.StopBoosters();
            
            _dissolveComponent.StartDissolve(() =>
            {
                transform.position = _currentRespawnPoint.GetRespawnPosition();
                _dissolveComponent.Reintegrate(null);
                _player.StartBoosters();
            });
            
            
        }

        public void SetRespawnPoint(RespawnPoint respawnPoint)
        {
            _currentRespawnPoint = respawnPoint;
        }
    }
}
