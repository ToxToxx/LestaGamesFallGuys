using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    public int Health { get; private set; }

    public static event Action OnPlayerDeath;
    public event Action<int> OnHealthChanged;

    private void Start()
    {
        Health = _maxHealth;
    }

    private void OnEnable()
    {
        PlayerBorderController.OnPlayerFalling += TakeDamage;
        DamageTrap.OnDamageDealt += TakeDamage;
    }

    private void OnDisable()
    {
        PlayerBorderController.OnPlayerFalling -= TakeDamage;
        DamageTrap.OnDamageDealt -= TakeDamage;
    }

    public void TakeDamage(int damageAmount)
    {
        if (Health <= 0) return; 

        Health = Mathf.Clamp(Health - damageAmount, 0, _maxHealth);
        OnHealthChanged?.Invoke(Health);

#if UNITY_EDITOR
        Debug.Log($"Player Health: {Health}");
#endif

        if (Health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        OnPlayerDeath?.Invoke();
    }
}
