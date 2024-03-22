using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleState : BattleState
{
    private BattleSystem battleSystem;
    private EnemyAI myAI;

    public void SetBattleSystem(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public void SetEnemyAI(EnemyAI enemyAI)
    {
        myAI = enemyAI;
    }

    public void StateAction()
    {
        Debug.Log("Enemy Turn");
        myAI.MakeDecision();
    }
}
