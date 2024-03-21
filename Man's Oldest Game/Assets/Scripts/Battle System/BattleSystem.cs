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

    private void OnEnable()
    {
        SetUpStateMachine();
        StartCoroutine("TestStateMachine");
    }

    IEnumerator TestStateMachine()
    {
        foreach(BattleState state in battleStates)
        {
            state.StateAction();
            yield return 0;
        }
    }

    public void SetUpStateMachine()
    {
        foreach(BattleState state in battleStates)
        {
            state.SetBattleSystem(this);
        }
    }

    public void SetState(BattleState state)
    {
        currentState = state;
    }

    public void StartBattle(Unit player, Unit enemy)
    {
        SetPlayer(player);
        SetEnemy(enemy);
        SetState(battleStates[0]);
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
