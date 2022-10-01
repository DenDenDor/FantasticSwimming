using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NextMoveButton : MonoBehaviour
{
    [SerializeField] private BattleWindow _battleWindow;
    private BattleSlotCreator _battleSlotCreator;
    private Enemy _enemy;
    public event Action OnStartNextMove;
    private void Awake() 
    {
      _battleWindow.OnSetEnemy += SetEnemy;
      _battleSlotCreator = FindObjectOfType<BattleSlotCreator>();
    }
    public void OnClick()
    {
        _enemy.EnemyAttack.Attack();
        _battleSlotCreator.IncreaseMovesOfSlots();
        OnStartNextMove?.Invoke();
    }
    private void SetEnemy(Enemy enemy) => _enemy = enemy; 
    private void OnDisable() 
    {
        _battleWindow.OnSetEnemy -= SetEnemy;
    }
}
