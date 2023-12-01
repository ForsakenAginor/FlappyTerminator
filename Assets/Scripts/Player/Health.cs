using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    protected int CurrentHealth
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

    public delegate void HealthChangeDelegate(int value);

    public event HealthChangeDelegate HealthChange;

    public delegate void DieDelegate();

    public event DieDelegate Die;

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
