using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Health))]
public class Player : MonoBehaviour
{
    private Vector3 _startPosition;
    private Rigidbody2D _rigidBody;
    private Health _health;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _startPosition = transform.position;
    }

    public delegate void CrashedDelegate();
    public event CrashedDelegate Crashed;

    public void Crash()
    {
        Crashed?.Invoke();
    }

    public void ResetPlayer()
    {
        _rigidBody.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = _startPosition;   
        _health.ResetHealth();
    }
}
