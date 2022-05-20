using System;
using TMPro;
using UnityEngine;

namespace Pickup_Logic
{
    public class Inventory : MonoBehaviour
    {
        public bool key;
        public bool key1;
        public bool key2;
        public bool hasSpring;
        public bool hasPortalAuthorization;
        public bool hasLamp;
        
        private int _count;
        private int _keyCount;

        [SerializeField] private GameObject _headband;
        [SerializeField] private GameObject _lamp;
        [SerializeField] private TextMeshProUGUI _numberOfCollectiblesFound;
        [SerializeField] private TextMeshProUGUI _numberOfKeysFound;
        [SerializeField] private TextMeshProUGUI _springFound;
        [SerializeField] private TextMeshProUGUI _pakFound;
        [SerializeField] private TextMeshProUGUI _lampFound;
        
        [SerializeField] private Animator _toastAnimator;
        [SerializeField] private TextMeshProUGUI _toastMessage;


        public void AddCollectible()
        {
            _count = _count + 1;
            _numberOfCollectiblesFound.text = $"Collectibles found: {_count}"; 
        }

        public void AddKey()
        {
            _keyCount = _keyCount + 1;
            _numberOfKeysFound.text = $"Keys found: {_keyCount} / 3";
            DisplayToast("You found a main gate key!");
        }

        public void DisplayToast(string message)
        {
            _toastMessage.text = message;
            _toastAnimator.SetTrigger("ShowToast");
        }

        private void UpdateText()
        {
            _springFound.enabled = hasSpring;
            _pakFound.enabled = hasPortalAuthorization;
            _lampFound.enabled = hasLamp;
        }

        private void ShowLamp()
        {
            if (hasLamp)
            {
                var headbandMeshrenderer = _headband.GetComponent<MeshRenderer>();
                var lampMeshrenderer = _lamp.GetComponent<MeshRenderer>();

                headbandMeshrenderer.enabled = true;
                lampMeshrenderer.enabled = true;
            }
        }

        private void Start()
        {
            
        }

        private void Update()
        { 
            ShowLamp();
            UpdateText();
        }
    }
}
