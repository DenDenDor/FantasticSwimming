using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour
{
    private PlayerInformation _playerInformation;
    public PlayerInformation PlayerInformation { get => _playerInformation; set => _playerInformation = value; }
    public event Action OnChangeHealth;
    public event Action OnDeath;
    public void ApplyDamage(int damage)
    {
        PlayerInformation.Health -= damage;
        OnChangeHealth?.Invoke();
        if (PlayerInformation.Health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
    public void Heal(int additionalHealth)
    {
        if(PlayerInformation.Health <= PlayerInformation.MaxHealth - additionalHealth)
        {
        PlayerInformation.Health += additionalHealth;
        OnChangeHealth?.Invoke();
        }
    }
}
