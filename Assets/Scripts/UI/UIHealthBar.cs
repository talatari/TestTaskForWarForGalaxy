using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake() => 
        _playerHealth.HealthChanged += OnPlayerHealthChanged;

    private void OnDestroy() => 
        _playerHealth.HealthChanged -= OnPlayerHealthChanged;

    private void OnPlayerHealthChanged(float currentHealth) => 
        _healthBarFilling.fillAmount = currentHealth;
}