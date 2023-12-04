using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubles : MonoBehaviour
{
    [SerializeField] private float _destroyDelay = 1;

    private void Awake()
    {
        Destroy(gameObject, _destroyDelay);
    }
}
