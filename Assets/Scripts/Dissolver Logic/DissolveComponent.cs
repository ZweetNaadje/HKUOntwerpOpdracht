using System;
using UnityEngine;

namespace Dissolver_Logic
{
    public class DissolveComponent : MonoBehaviour
    {
        [SerializeField] private float _dissolveTime = 3.0f;
        [SerializeField] private MeshRenderer _meshRenderer;

        private Action _onComplete;
        private Action _onCompleteReintegrate;
        private bool _didDissolve = false;
        private float _dissolveTimer = 0.0f;
        private bool _didReintegrate = false;

        public bool UseSharedMaterial = false;
        public bool IsHit;

        private void DissolveAnimation()
        {
            if (!_didDissolve)
            {
                return;
            }

            _dissolveTimer += Time.deltaTime;
            _dissolveTimer = Mathf.Clamp(_dissolveTimer, 0.0f, _dissolveTime);
            float progress = _dissolveTimer / _dissolveTime;
            
            if (!UseSharedMaterial)
            {
                _meshRenderer.material.SetFloat("_DissolveStrength", progress);
            }
            else
            {
                _meshRenderer.sharedMaterial.SetFloat("_DissolveStrength", progress);
            }

            if (progress >= 1.0f)
            {
                _didDissolve = false;
                _dissolveTimer = 0.0f;
                _onComplete?.Invoke();
                _onComplete = null;
            }
        }
        
        private void ReintegrateAnimation()
        {
            if (!_didReintegrate)
            {
                return;
            }

            _dissolveTimer += Time.deltaTime;
            _dissolveTimer = Mathf.Clamp(_dissolveTimer, 0.0f, _dissolveTime);
            float progress = 1.0f - (_dissolveTimer / _dissolveTime);
            
            if (!UseSharedMaterial)
            {
                _meshRenderer.material.SetFloat("_DissolveStrength", progress);
            }
            else
            {
                _meshRenderer.sharedMaterial.SetFloat("_DissolveStrength", progress);
            }

            if (progress <= 0.00001f)
            {
                _didReintegrate = false;
                _dissolveTimer = 0.0f;
                _onCompleteReintegrate?.Invoke();
                _onCompleteReintegrate = null;
            }
        }

        public void StartDissolve(Action onComplete)
        {
            IsHit = true;
            _onComplete = onComplete;
            _didDissolve = true;
        }

        public void Reintegrate(Action onComplete)
        {
            IsHit = false;
            _onCompleteReintegrate = onComplete;
            _didReintegrate = true;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            DissolveAnimation();
            ReintegrateAnimation();
        }
    }
}
