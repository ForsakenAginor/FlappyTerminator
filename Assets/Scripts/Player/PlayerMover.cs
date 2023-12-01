using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidBody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxAngle);
        _minRotation = Quaternion.Euler(0, 0, _minAngle);
    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space) )
        {
            _rigidBody.velocity = new Vector2(_speed, 0);
            _rigidBody.AddForce(Vector2.up *  _force);
            transform.rotation = _maxRotation;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
