using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorpedoLauncher : TorpedoLauncher
{
    [SerializeField] private Transform _torpedoLauncherPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))        
            Launch(_torpedoLauncherPoint.position, transform.rotation);        

        DisableObjectsAbroadScreen();
    }
}
