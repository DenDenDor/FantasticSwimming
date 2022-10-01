using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackAbility", menuName = "ScriptableObjects/ItemAbility/AttackAbility")]
public class AttackAbility : ItemAbility
{
    [SerializeField] private int _damage = 2;
    protected override void ActiveAbility()
    {
        FindObjectOfType<EnemyHealth>().ApplyDamage(_damage);
    }

}
