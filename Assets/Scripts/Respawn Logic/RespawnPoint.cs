using UnityEngine;

namespace Respawn_Logic
{
    public class RespawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform _respawnTransform;

        public Vector3 GetRespawnPosition()
        {
            return _respawnTransform.position;
        }
    }
}
