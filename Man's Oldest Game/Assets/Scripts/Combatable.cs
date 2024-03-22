using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatable: MonoBehaviour
{
    [Header("Camera and Input Systems")]
    [SerializeField] GameObject battleSystem;
    private BattleSystem battleSystemScript;
    [SerializeField] GameObject adventureSystem;
    [Header("My Combat Data")]
    [SerializeField] Unit myUnit;

    private void Start()
    {
        battleSystemScript = battleSystem.transform.GetChild(0).GetComponent<BattleSystem>();
        myUnit = GetComponent<Unit>();
    }

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
        battleSystemScript.AdventureToCombat(adventureSystem);
        battleSystemScript.StartBattle(player, myUnit);
    }
}
