using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleState : BattleState
{
    private BattleSystem battleSystem;

    public void SetBattleSystem(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public void StateAction()
    {
        Debug.Log("Starting Battle");
    }
}
