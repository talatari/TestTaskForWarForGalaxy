using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public event Action<float> HealthChanged;

    private void Start() => 
        _currentHealth = _maxHealth;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            ChangeHealth(10);
    }

    private void ChangeHealth(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Death();
        else
            HealthChanged?.Invoke((float)_currentHealth / _maxHealth);
    }

    private void Death() => 
        HealthChanged?.Invoke(0);
}