using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttack", menuName = "ScriptableObjects/EnemyAttack")]
public class EnemyAttack : ScriptableObject
{
  [SerializeField] private int _damage = 6;
  public void Attack()
  {
    PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
    playerHealth.ApplyDamage(_damage);
  }
}
