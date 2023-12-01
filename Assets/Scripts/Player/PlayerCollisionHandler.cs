using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent (typeof(Health))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;
    private Health _health;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Border>(out _) || collision.TryGetComponent<Enemy>(out _))
        {
            _player.Crash();
        }
        else if(collision.TryGetComponent<Torpedo>(out Torpedo torpedo))
        {
            torpedo.Detonate();
            _health.TakeDamage();
        }
    }
}
