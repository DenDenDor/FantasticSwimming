using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthOutPut : MonoBehaviour
{
   [SerializeField] private BattleWindow _battleWindow;
   [SerializeField] private Image _healthBar;
   [SerializeField] private EnemyHealth _enemyHealth;
   private Enemy _currentEnemy;
   private float _fillValue;
   private void Awake() 
   {
    _battleWindow.OnSetEnemy += SetEnemy;
    _enemyHealth.OnApplyDamage += ShowHealth;
   }
   private void SetEnemy(Enemy enemy)
   {
    _currentEnemy = enemy;
   } 
   public void ShowHealth()
   {
      _healthBar.DivideImageBar(_currentEnemy.MaxHealth,_currentEnemy.Health);
   }
   private void OnDisable() 
   {
     _battleWindow.OnSetEnemy -= SetEnemy;
      _enemyHealth.OnApplyDamage -= ShowHealth;
   }
}
