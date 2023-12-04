using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Health => _health;

    private void Start()
    {
        OnHealthChange(_health.MaxHealth);
        _health.HealthChange += OnHealthChange;
    }

    private void OnDestroy()
    {
        _health.HealthChange -= OnHealthChange;
    }

    protected abstract void OnHealthChange(int value);
}
