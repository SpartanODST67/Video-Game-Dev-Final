using System.Collections;
using System.Collections.Generic;
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
        battleSystem.DestroyBattleStationCombatants();
        //RewardPlayer();
        //I would fire myself if I saw this.
        GameObject enemy = battleSystem.GetEnemy().gameObject;
        enemy.AddComponent<DestroyOnDisable>();
        enemy.SetActive(false);
        battleSystem.EndBattle();
    }
}
