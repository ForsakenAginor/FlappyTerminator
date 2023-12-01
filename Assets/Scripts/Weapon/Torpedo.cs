using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Torpedo : MonoBehaviour
{
    [SerializeField] private LayerMask _ownerLayerMask;
    [SerializeField] private GameObject _explosionPrefab;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _collider.excludeLayers = _ownerLayerMask;
    }

    public void Detonate()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
