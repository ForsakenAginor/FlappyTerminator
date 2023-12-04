using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubles : MonoBehaviour
{
    [SerializeField] private float _destroyDelay = 1;

    private void Start()
    {
        Destroy(gameObject, _destroyDelay);
    }
}
