using UnityEngine;

namespace Respawn_Logic
{
    public class RespawnBehaviour : MonoBehaviour
    {
        private RespawnPoint _currentRespawnPoint;

        public void Respawn()
        {
            if (_currentRespawnPoint == null)
            {
                return;
            }
            
            transform.position = _currentRespawnPoint.GetRespawnPosition();
        }

        public void SetRespawnPoint(RespawnPoint respawnPoint)
        {
            _currentRespawnPoint = respawnPoint;
        }
    }
}
