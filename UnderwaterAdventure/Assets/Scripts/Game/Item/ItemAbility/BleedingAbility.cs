using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackAbility", menuName = "ScriptableObjects/ItemAbility/AttackAbility")]
public class BleedingAbility : ItemAbility
{
   [SerializeField] private int _damage = 2;
    protected override void ActiveAbility()
    {
       EnemyHealth enemyHealth = FindObjectOfType<EnemyHealth>();
       enemyHealth.ApplyDamage(_damage);
       //enemyHealth.EnemyEffect = new EnemyBleedingEffect();
    }
}
