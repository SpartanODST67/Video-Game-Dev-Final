using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Unit Stats")]
    [SerializeField] int health = 3;
    private EnemyAI myAI;

    private void OnEnable()
    {
        myAI = GetComponent<EnemyAI>();
    }

    public int GetHealth()
    {
        return health;
    }

    public int TakeDamage(int damage)
    {
        health -= damage;
        return health;
    }

    public int Heal(int health)
    {
        this.health += health;
        return this.health;
    }

    public EnemyAI GetAI()
    {
        if(myAI == null)
        {
            Debug.Log("Attempted to recieve AI when no AI component assigned");
            return new DumbAI();
        }
        return myAI;
    }
}
