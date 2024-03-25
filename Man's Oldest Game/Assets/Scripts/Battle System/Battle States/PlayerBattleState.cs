using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleState : BattleState
{
    private BattleSystem battleSystem;
    private CombatInputHandler inputHandler;
    private GameObject buttons;
    private AttackSelection attack;

    public void SetBattleSystem(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public void SetInputHandler(CombatInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public void SetSelectedAttack(AttackSelection attack)
    {
        this.attack = attack;
    }

    public void StateAction()
    {
        Debug.Log("Player Turn");
        inputHandler.SetBattleSystem(battleSystem);
        battleSystem.SetPlayerBluff(AttackSelection.NULL);
        battleSystem.ShowButtonSelection();
        inputHandler.GetInputAction();
    }

}
