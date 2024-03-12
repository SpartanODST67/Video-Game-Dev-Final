using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCombat : MonoBehaviour
{
    [SerializeField] GameObject BattleSystem;
    [SerializeField] GameObject AdventureSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            InitiateCombat();
        }
    }

    public void InitiateCombat()
    {
        Debug.Log("Entering Combat");
        BattleSystem.SetActive(true);
        AdventureSystem.SetActive(false);
    }
}
