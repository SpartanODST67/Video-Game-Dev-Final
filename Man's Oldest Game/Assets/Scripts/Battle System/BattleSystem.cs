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

    private List<BattleState> battleStates = new List<BattleState>() { new StartBattleState(), new PlayerBattleState(), new EnemyBattleState(), new WaitBattleState(), new LoseBattleState(), new WinBattleState()};

    private void Start()
    {
        StartCoroutine("TestBattleStates");
    }

    IEnumerator TestBattleStates()
    {
        foreach (BattleState state in battleStates)
        {
            state.StateAction();
            yield return 0;
        }
    }

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
