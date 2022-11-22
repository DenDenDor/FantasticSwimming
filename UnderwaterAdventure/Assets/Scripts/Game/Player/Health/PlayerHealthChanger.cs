using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealthChanger : PlayerDamageHandler
{
    public override void ApplyDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new InvalidOperationException();
        }
        _playerInformation.Health -= damage;
    }
    public PlayerHealthChanger(PlayerInformation playerInfrormation)
   {
    _playerInformation = playerInfrormation;
   }

}
