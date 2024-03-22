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
    private BattleState currentState;


    public void SetState(BattleState state)
    {
        currentState = state;
    }

    public void TriggerState()
    {
        currentState.StateAction();
    }

    public void SetPlayer(Unit player)
    {
        playerUnit = player;
    }

    public void SetEnemy(Unit enemy)
    {
        enemyUnit = enemy;
    }

    //Why did I make a StartBattleState???
    public void StartBattle(Unit player, Unit enemy)
    {
        SetPlayer(player);
        SetEnemy(enemy);
        InstantiateBattleStationCombatants();
        InitializeStateMachine();
    }

    //This is so hacky
    public void InstantiateBattleStationCombatants()
    {
        GameObject unit = Instantiate(enemyUnit.gameObject, enemyBattleStation);
        unit.transform.localPosition = Vector3.zero;
        unit = Instantiate(playerUnit.gameObject, playerBattleStation);
        unit.transform.localPosition = Vector3.zero;
    }

    public void DestroyBattleStationCombatants()
    {
        Destroy(enemyBattleStation.transform.GetChild(0).gameObject);
        Destroy(playerBattleStation.transform.GetChild(0).gameObject);
    }

    public void InitializeStateMachine()
    {
        foreach (BattleState state in battleStates)
        {
            state.SetBattleSystem(this);
        }
        SetState(battleStates[1]);
    }
}
