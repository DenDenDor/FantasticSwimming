using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NextMoveButton : MonoBehaviour
{
    [SerializeField] private BattleWindow _battleWindow;
    private BattleSlotCreator _battleSlotCreator;
    private Enemy _enemy;
    private EnemyMovesReloader _enemyMovesReloader;
    public EnemyMovesReloader EnemyMovesReloader { get => _enemyMovesReloader; private set => _enemyMovesReloader = value; }
    public event Action OnStartNextMove;
    private void Awake() 
    {
      _battleWindow.OnSetEnemy += SetEnemy;
      _battleSlotCreator = FindObjectOfType<BattleSlotCreator>();
    }
    public void OnClick()
    {
        EnemyMovesReloader.IncreaseCountOfMovesOfEnemy();
        _battleSlotCreator.IncreaseMovesOfSlots();
        OnStartNextMove?.Invoke();
    }
    private void SetEnemy(Enemy enemy)
    {
         _enemy = enemy;
        EnemyMovesReloader = new EnemyMovesReloader(_enemy.EnemyAttack.Attack);
    } 
    private void OnDisable() 
    {
        _battleWindow.OnSetEnemy -= SetEnemy;
    }
}
