using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAmbience : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ambience");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
