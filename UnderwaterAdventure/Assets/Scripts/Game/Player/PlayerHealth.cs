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
    public void SetStartHealth()
    {
        SavableHealth savableHealth = Loader<SavableHealth>.Load(new SavableHealth());
        OnChangeHealth += SaveHealth;
        PlayerInformation.Health = savableHealth != null ? TryGetSavableHealth() :SetMaxHealth();

        int TryGetSavableHealth() => PlayerInformation.Health = savableHealth.Health != "" ? Convert.ToInt32(savableHealth.Health) : SetMaxHealth();
        
        int SetMaxHealth() => PlayerInformation.Health = PlayerInformation.MaxHealth;
    }
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
    private void SaveHealth() => Saver<SavableHealth>.Save(new SavableHealth(PlayerInformation.Health));
    private void OnDisable() 
    {
      OnChangeHealth -= SaveHealth;   
    }
}
