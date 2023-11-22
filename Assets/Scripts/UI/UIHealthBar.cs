using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Gradient _gradient;

    private void Awake() => 
        _playerHealth.HealthChanged += OnPlayerHealthChanged;

    private void OnDestroy() => 
        _playerHealth.HealthChanged -= OnPlayerHealthChanged;

    private void OnPlayerHealthChanged(float currentHealth)
    {
        _healthBarFilling.fillAmount = currentHealth;
        _healthBarFilling.color = _gradient.Evaluate(currentHealth);
    }
}