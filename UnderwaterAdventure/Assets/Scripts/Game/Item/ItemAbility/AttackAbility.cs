using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackAbility", menuName = "ScriptableObjects/ItemAbility/AttackAbility")]
public class AttackAbility : ItemAbility
{
    [SerializeField] private int _damage = 2;

    public int Damage { get => _damage; set => _damage = value; }

    protected override void ActiveAbility()
    {
        FindObjectOfType<EnemyHealth>().ApplyDamage(Damage);
    }

}
