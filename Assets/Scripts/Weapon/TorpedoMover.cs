using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TorpedoMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidBody.velocity = Vector3.zero;
        Vector2 direction = transform.TransformDirection(new Vector3(1,0,0));
        _rigidBody.velocity = direction * _speed;
    }
}
