using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private float _fireRate;

    private TorpedoLauncher _launcher;
    private float _rearmDelay;

    private void Update()
    {
        if (_rearmDelay <= 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, float.MaxValue, _playerLayerMask);

            if (hit)
            {
                _launcher.Launch(transform.position, transform.rotation);
                _rearmDelay = _fireRate;
            }
        }

        _rearmDelay -= Time.deltaTime;
    }

    public void SetTorpedoLauncer(TorpedoLauncher launcher)
    {
        _launcher = launcher;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Torpedo torpedo))
        {
            torpedo.Detonate();
            gameObject.SetActive(false);
        }
    }
}
