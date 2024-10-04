using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3; 
    public int Health { get; private set; }

    public event Action OnPlayerDeath;  
    public event Action<int> OnHealthChanged;  

    private void Start()
    {
        Health = _maxHealth;  
    }
    private void OnEnable()
    {
        DamageTrap.OnDamageDealt += TakeDamage; 
    }

    private void OnDisable()
    {
        DamageTrap.OnDamageDealt -= TakeDamage; 
    }

    public void TakeDamage(int damageAmount)
    {
        if (Health <= 0) return;  

        Health = Mathf.Clamp(Health - damageAmount, 0, _maxHealth);  
        OnHealthChanged?.Invoke(Health);

        Debug.Log(Health);

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
