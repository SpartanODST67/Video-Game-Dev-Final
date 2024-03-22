using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [Header("System to Transer Back To")]
    [SerializeField] GameObject adventureSystem;
    [Header("Input Handler")]
    [SerializeField] CombatInputHandler inputHandler;
    [Header("Combat Units")]
    [SerializeField] Unit playerUnit;
    [SerializeField] Unit enemyUnit;
    [Header("Battle Stations")]
    [SerializeField] Transform playerBattleStation;
    [SerializeField] Transform enemyBattleStation;
    private GameObject stationedPlayer;
    private GameObject stationedEnemy;
    [Header("Battle UI")]
    [SerializeField] Canvas battleUI;

    private AttackSelection playerAttack;
    private AttackSelection enemyAttack;

    private List<BattleState> battleStates = new List<BattleState>() { new StartBattleState(), new PlayerBattleState(), new EnemyBattleState(), new WaitBattleState(), new LoseBattleState(), new WinBattleState()};
    private BattleState currentState;


    public void SetState(BattleState state)
    {
        currentState = state;
    }

    public BattleState GetCurrentState()
    {
        return currentState;
    }

    public BattleState GetState(int i)
    {
        return battleStates[i];
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

    public void SetPlayerAttack(AttackSelection attack)
    {
        playerAttack = attack;
    }

    public void SetEnemyAttack(AttackSelection attack)
    {
        enemyAttack = attack;
    }
    public Unit GetPlayer()
    {
        return playerUnit;
    }

    public Unit GetEnemy()
    {
        return enemyUnit;
    }

    public AttackSelection GetPlayerAttack()
    {
        return playerAttack;
    }

    public AttackSelection GetEnemyAttack()
    {
        return enemyAttack;
    }

    //Why did I make a StartBattleState???
    public void StartBattle(Unit player, Unit enemy)
    {
        Random.InitState((int) Time.time);
        SetPlayer(player);
        SetEnemy(enemy);
        InstantiateBattleStationCombatants();
        InitializeStateMachine();
        currentState.StateAction();
    }

    public void EndBattle()
    {
        adventureSystem.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    //This is so hacky
    public void InstantiateBattleStationCombatants()
    {
        stationedEnemy = Instantiate(enemyUnit.gameObject, enemyBattleStation);
        stationedEnemy.transform.localPosition = Vector3.zero;
        stationedPlayer = Instantiate(playerUnit.gameObject, playerBattleStation);
        stationedPlayer.transform.localPosition = Vector3.zero;
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
        //What am I doing?
        EnemyBattleState tempState = (EnemyBattleState) battleStates[2];
        tempState.SetEnemyAI(enemyUnit.GetAI());
        PlayerBattleState tempState2 = (PlayerBattleState) battleStates[1];
        tempState2.SetInputHandler(inputHandler);
        SetState(battleStates[1]);
    }
}
