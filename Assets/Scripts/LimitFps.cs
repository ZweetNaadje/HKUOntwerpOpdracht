using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFps : MonoBehaviour
{
    public int TargetFrameRate = 144;
    public int Vsync = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = Vsync;
        Application.targetFrameRate = TargetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
