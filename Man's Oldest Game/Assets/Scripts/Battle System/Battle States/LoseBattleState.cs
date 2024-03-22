using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        battleSystem.DestroyBattleStationCombatants();
        //RewardPlayer();
        battleSystem.GetEnemy().gameObject.SetActive(false);
        battleSystem.EndBattle();
    }
}
