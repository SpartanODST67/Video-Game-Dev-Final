using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class CombatInputHandler : MonoBehaviour
{
    AttackSelection selectedAttack;
    AttackSelection selectedBluff;
    BattleSystem battleSystem;

    public void SetBattleSystem(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public void GetInputAction()
    {
        Debug.Log("Awaiting Input");
        StartCoroutine("WaitForInputCoroutine");
    }

    IEnumerator WaitForInputCoroutine()
    {
        bool waitingInput = true;
        while (waitingInput)
        {
            yield return 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Rock");
                selectedAttack = AttackSelection.ROCK;
                waitingInput = false;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Paper");
                selectedAttack = AttackSelection.PAPER;
                waitingInput = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Scissors");
                selectedAttack = AttackSelection.SCISSORS;
                waitingInput = false;
            }
        }
        ReturnSelectedAttack();
    }

    public void ButtonAttackSelect(int attack)
    {
        selectedAttack = (AttackSelection)attack;
        Debug.Log(selectedAttack.ToString());
        StopCoroutine("WaitForInputCoroutine");
        ReturnSelectedAttack();
    }

    public void ButtonBluffSelect(int bluff)
    {
        selectedBluff = (AttackSelection)bluff;
        Debug.Log("Bluffing: " + selectedBluff.ToString());
        battleSystem.SetPlayerBluff(selectedBluff);
    }

    private void ReturnSelectedAttack()
    {
        battleSystem.SetPlayerAttack(selectedAttack);
        battleSystem.SetState(battleSystem.GetState(2));
        battleSystem.TriggerState();
    }
}
