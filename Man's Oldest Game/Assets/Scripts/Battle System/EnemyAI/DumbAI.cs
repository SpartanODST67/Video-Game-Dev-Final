using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAI : MonoBehaviour, EnemyAI
{
    public AttackSelection MakeDecision()
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
