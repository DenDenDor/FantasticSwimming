using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyMovesReloader
{
    private int _currentCountMoves = 0;
    private int _maxCountOfMoves = 1;
    private int _startCountOfMoves;
    private Action _action;

    public int MaxCountOfMoves { get => _maxCountOfMoves; set => _maxCountOfMoves = value; }

    public EnemyMovesReloader(Action action)
    {
        _action = action;
        _startCountOfMoves = _maxCountOfMoves;
    }
    public void SetCountOfMoves(int maxCountOfMoves)
    {
        MaxCountOfMoves = maxCountOfMoves;
    }
    public void IncreaseCountOfMovesOfEnemy()
    {
        _currentCountMoves++;
        if (MaxCountOfMoves <= _currentCountMoves)
        {
            _action.Invoke();
            _maxCountOfMoves = _startCountOfMoves;
            _currentCountMoves= 0;
        }
    }

}
