using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAI : MonoBehaviour, EnemyAI
{
    private AttackSelection playerBluff;
    
    public AttackSelection MakeDecision()
    {
        if(IsFooled())
        {
            return FooledMove();
        }
        return DecideMove();
    }

    public void SetPlayerBluff(AttackSelection bluff)
    {
        playerBluff = bluff;
    }

    public bool IsFooled()
    {
        if (playerBluff != AttackSelection.NULL)
        {
            return true;
        }
        return false;
    }

    public AttackSelection FooledMove()
    {
        if(playerBluff == AttackSelection.ROCK)
        {
            Debug.Log("Paper");
            return AttackSelection.PAPER;
        }
        else if(playerBluff == AttackSelection.PAPER)
        {
            Debug.Log("Scissors");
            return AttackSelection.SCISSORS;
        }
        else if(playerBluff == AttackSelection.SCISSORS)
        {
            Debug.Log("Rock");
            return AttackSelection.ROCK;
        }
        else
        {
            return DecideMove();
        }
    }

    private AttackSelection DecideMove()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                Debug.Log("Rock");
                return AttackSelection.ROCK;
            case 1:
                Debug.Log("Paper");
                return AttackSelection.PAPER;
            case 2:
                Debug.Log("Scissors");
                return AttackSelection.SCISSORS;
            default:
                Debug.Log(string.Format("Unexpected random number: %d", rand));
                //TODO: Make a proper error
                return AttackSelection.ROCK;
        }
    }

}
