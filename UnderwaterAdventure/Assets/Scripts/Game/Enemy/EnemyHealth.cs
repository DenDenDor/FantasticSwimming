using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyHealth : MonoBehaviour
{
   [SerializeField] private BattleWindow _battleWindow;
   private Enemy _currentEnemy;
   private List<EnemyEffect> _listOfEnemyEffect;
   public event Action OnApplyDamage;
   public event Action OnDeath;
   private void Awake() 
   {
    _battleWindow.OnSetEnemy += SetEnemy;
   }
    private void SetEnemy(Enemy enemy)
   {
    _currentEnemy = enemy;
    _currentEnemy.Health = _currentEnemy.MaxHealth;
   } 
   public void ApplyDamage(int damage)
   {
    _currentEnemy.Health -= damage;
    //_listOfEnemyEffect.ForEach(e=>e.);
    OnApplyDamage?.Invoke();
    if (_currentEnemy.Health <= 0)
    {
      _battleWindow.EndBattle();
    }
   }
   private void OnDisable() 
   {
         _battleWindow.OnSetEnemy -= SetEnemy;
   }
}
