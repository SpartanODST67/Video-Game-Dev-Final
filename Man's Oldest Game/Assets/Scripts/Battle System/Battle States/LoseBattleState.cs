using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseBattleState : BattleState
{
    private BattleSystem battleSystem;

    public void SetBattleSystem(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public void StateAction()
    {
        Debug.Log("Lost Battle");
        battleSystem.DestroyPlayerBattleStationCombatant();
        battleSystem.Defeat();
    }
}
