using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HealAbility", menuName = "ScriptableObjects/ItemAbility/HealAbility")]
public class HealAbility : ItemAbility
{
    [SerializeField] private int _additionalHealth = 2;
    protected override void ActiveAbility()
    {
        FindObjectOfType<PlayerHealth>().Heal(_additionalHealth);
    }
}
