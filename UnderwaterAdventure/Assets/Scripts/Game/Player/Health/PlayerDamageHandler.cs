using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDamageHandler
{
   private protected PlayerInformation _playerInformation;
   public abstract void ApplyDamage(int damage);
}
