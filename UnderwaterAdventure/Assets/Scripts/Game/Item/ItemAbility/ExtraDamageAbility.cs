using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ExtraDamageAbility", menuName = "ScriptableObjects/ItemAbility/ExtraDamageAbility")]
public class ExtraDamageAbility : ItemAbility, IAbilityBeforePlayerMove
{
    [SerializeField] private int _extraValueOfDamage = 2;
    protected override void ActiveAbility()
    {
        throw new System.NotImplementedException();
    }
    public Action<ItemAbility> UseAbilityBeforePlayerMove()
    {
        return (ability) =>
        {
            AttackAbility itemAbility = new AttackAbility();
            itemAbility.Damage *= _extraValueOfDamage;
        };
    }
}
