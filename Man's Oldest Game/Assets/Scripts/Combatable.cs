using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatable: MonoBehaviour
{
    [Header("Camera and Input Systems")]
    [SerializeField] GameObject BattleSystem;
    [SerializeField] GameObject AdventureSystem;
    [Header("My Combat Data")]
    [SerializeField] Unit myUnit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            InitiateCombat(collision.gameObject.GetComponent<Unit>());
        }
    }

    public void InitiateCombat(Unit player)
    {
        Debug.Log("Entering Combat");
        BattleSystem.SetActive(true);
        AdventureSystem.SetActive(false);
        BattleSystem.transform.GetChild(0).GetComponent<BattleSystem>().StartBattle(player, myUnit);
    }
}
