using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoLauncher : ObjectPoolGenerator
{
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        DisableObjectsAbroadScreen();
    }

    public void Launch(Vector3 position, Quaternion rotation)
    {
        if (TryGetObjectFromPool(out GameObject spawned))
        {
            spawned.transform.position = position;
            spawned.transform.rotation = rotation;
            spawned.SetActive(true);
        }
    }
}
