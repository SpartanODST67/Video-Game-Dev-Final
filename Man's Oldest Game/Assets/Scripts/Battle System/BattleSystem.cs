using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [Header("Combat Units")]
    [SerializeField] Unit playerUnit;
    [SerializeField] Unit enemyUnit;
    [Header("Battle Stations")]
    [SerializeField] Transform playerBattleStation;
    [SerializeField] Transform enemyBattleStation;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle(Unit player, Unit enemy)
    {
        SetPlayer(player);
        SetEnemy(enemy);
    }

    public void SetPlayer(Unit player)
    {
        playerUnit = player;
    }

    public void SetEnemy(Unit enemy)
    {
        enemyUnit = enemy;
    }
}
