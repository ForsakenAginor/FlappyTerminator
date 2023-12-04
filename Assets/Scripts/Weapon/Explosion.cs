using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        float destroyDelay = 1;
        Destroy(gameObject, destroyDelay);
    }
}
