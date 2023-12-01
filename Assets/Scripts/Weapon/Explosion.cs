using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Awake()
    {
        float destroyDelay = 1;
        Destroy(gameObject, destroyDelay);
    }
}
