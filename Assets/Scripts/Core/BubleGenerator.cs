using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleGenerator : MonoBehaviour
{
    [SerializeField] private Transform _bublePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnSpeed;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        bool isMoving = true;
        WaitForSeconds spawnDelay = new WaitForSeconds(_spawnSpeed);
        Quaternion quaternion;
        float doublePiRad = 360;

        while (isMoving)
        {
            quaternion = Quaternion.Euler(0, 0, Random.Range(0, doublePiRad));
            Instantiate(_bublePrefab, _spawnPoint.position, quaternion);
            yield return spawnDelay;
        }
    }
}
