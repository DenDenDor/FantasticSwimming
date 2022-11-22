using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerArmorPointsChanger : PlayerDamageHandler
{
    private PlayerHealth _playerHealth;
    public override void ApplyDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new InvalidOperationException();
        }
        _playerInformation.ArmorPoints -= damage;
        if (_playerInformation.ArmorPoints <= 0)
        {
           _playerHealth.SetPlayerDamageHandler();
        }
    }
    public PlayerArmorPointsChanger(PlayerInformation playerInfrormation, PlayerHealth playerHealth, int countOfArmorPoints)
   {
    _playerInformation = playerInfrormation;
    _playerInformation.MaxArmorPoints = countOfArmorPoints;
    _playerInformation.ArmorPoints = _playerInformation.MaxArmorPoints;
    _playerHealth = playerHealth;
   }

}
