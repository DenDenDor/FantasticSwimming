using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StunEnemyAbility", menuName = "ScriptableObjects/ItemAbility/StunEnemyAbility")]
public class StunEnemyAbility : ItemAbility
{
    [SerializeField] private int _maxCountOfMoves = 1;
    protected override void ActiveAbility()
    {
      NextMoveButton nextMoveButton =  FindObjectOfType<NextMoveButton>();
      nextMoveButton.EnemyMovesReloader.SetCountOfMoves(_maxCountOfMoves + nextMoveButton.EnemyMovesReloader.MaxCountOfMoves);
    }
}
