using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAI : MonoBehaviour, EnemyAI
{
    public void MakeDecision()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                Debug.Log("Rock");
                break;
            case 1:
                Debug.Log("Paper");
                break;
            case 2:
                Debug.Log("Scissors");
                break;
            default:
                Debug.Log(string.Format("Unexpected random number: %d", rand));
                break;
        }
    }

}
