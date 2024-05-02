using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatable: MonoBehaviour
{
    [Header("Camera and Input Systems")]
    [SerializeField] GameObject battleSystem;
    [SerializeField] GameObject adventureSystem;
    [Header("My Combat Data")]
    [SerializeField] Unit myUnit;
    [Header("My Movement Brain")]
    [SerializeField] GameObject movementBrain;

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
        movementBrain.SetActive(false);
        battleSystem.SetActive(true);
        adventureSystem.SetActive(false);
        battleSystem.transform.GetChild(0).GetComponent<BattleSystem>().StartBattle(player, myUnit);
    }
}
