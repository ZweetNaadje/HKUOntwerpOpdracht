using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //[SerializeField] private Checkpoint _currentCheckPoint;
    [SerializeField] private ThirdPersonController _thirdPersonController;
    //[SerializeField] private GameObject _springGameObject;
    //[SerializeField] private Inventory _inventory;
    [SerializeField] private ParticleSystem _jumpParticleSystem;
    [SerializeField] private Animator _animator;
    [SerializeField] private InputActionReference _jumpReference;
    [SerializeField] private StarterAssetsInputs _input;
    
    private string _animatorJumpKey = "JumpTrigger";
    
    private void CheckInput()
    {
        Debug.Log($"grounded: {_thirdPersonController.Grounded}");
        
        if (_input.jump && _thirdPersonController.Grounded)
        {
            Debug.Log($"grounded: {_thirdPersonController.Grounded}");
            
            //FMODUnity.RuntimeManager.PlayOneShot("event:/Jump", transform.position);
            _jumpParticleSystem.Play();
            InitialJump();
        }
    }

    private void InitialJump()
    {
        Debug.Log("InitialJump testing");
        _animator.SetTrigger(_animatorJumpKey);
    }
    
    
    // Update is called once per frame
    private void Update()
    {
        //CheckInput();
    }
}