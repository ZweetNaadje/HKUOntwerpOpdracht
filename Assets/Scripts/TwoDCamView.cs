using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Pickup_Logic;
using Player_Handler;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class TwoDCamView : MonoBehaviour
{
    // Bool to see if we are in a 2D cam zone
    // Detect player who entered the 2D cam zone
    // Change regular cam to side cam to ''fake'' a 2d cam
    // disable mouse movement
    // Change cam view and mouse movement back to normal upon exit of 2d cam zone

    [SerializeField] private StarterAssetsInputs _starterAssetsInputs;
    [SerializeField] private Player _player;
    [SerializeField] private ThirdPersonController _thirdPersonController;
    
    public CinemachineVirtualCamera TwoDCamera;
    public bool EnteredTwoDCamZone;

    private void ChangeToTwoDCamView()
    {
        if (EnteredTwoDCamZone == true)
        {
            Debug.Log("in de if");
            TwoDCamera.enabled = true;
            _thirdPersonController.VirtualMainCamera.enabled = false;
            _thirdPersonController.VirtualAimCamera.enabled = false;
            _starterAssetsInputs.cursorInputForLook = false;
        }
        else
        {
            Debug.Log("in de else");
            TwoDCamera.enabled = false;
            _starterAssetsInputs.cursorInputForLook = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var hasInventory = _player.GetComponent<Inventory>();

        if (!hasInventory)
        {
            return;
        }
        
        EnteredTwoDCamZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        EnteredTwoDCamZone = false;
    }

    void Start()
    {
        EnteredTwoDCamZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeToTwoDCamView();
    }
}
