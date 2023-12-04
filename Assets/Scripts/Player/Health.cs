using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event Action<int> HealthChange;
    public event Action Die;

    public int MaxHealth => _maxHealth;
    private int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            if (_currentHealth == value)
                return;

            _currentHealth = value;
            HealthChange?.Invoke(_currentHealth);
        }
    }

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage()
    {
        CurrentHealth--;

        if(CurrentHealth <= 0)
        {
            Die?.Invoke();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = _maxHealth;
    }
}
