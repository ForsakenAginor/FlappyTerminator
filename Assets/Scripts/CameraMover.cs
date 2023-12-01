using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _position;
    private float _xOffSet;

    private void Awake()
    {
        _xOffSet = _player.position.x;
    }

    private void Update()
    {
        _position = transform.position;
        _position.x = _player.position.x - _xOffSet;
        transform.position = _position;    
    }
}
