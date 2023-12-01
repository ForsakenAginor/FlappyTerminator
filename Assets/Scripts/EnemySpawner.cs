using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : ObjectPoolGenerator
{
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _spawnFrequency;

    private void Start()
    {
        Initialize();
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        DisableObjectsAbroadScreen();
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(_spawnFrequency);
        float yPosition;

        while (TryGetObjectFromPool(out GameObject spawned))
        {
            yPosition = Random.Range(_minPositionY, _maxPositionY);
            spawned.transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
            spawned.SetActive(true);
            yield return spawnDelay;
        }
    }
}
