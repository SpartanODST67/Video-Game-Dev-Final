using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WinBattleState : BattleState
{
    private BattleSystem battleSystem;

    public void SetBattleSystem(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public void StateAction()
    {
        Debug.Log("Won Battle");
        CleanBattleStations();
        //RewardPlayer();

    }

    private void CleanBattleStations()
    {
        battleSystem.DestroyBattleStationCombatants();
        battleSystem.EndBattle();
    }
}
