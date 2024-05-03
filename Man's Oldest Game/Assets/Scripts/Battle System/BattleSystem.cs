using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] Transform playerThrowPoint;
    [SerializeField] Transform enemyThrowPoint;
    [SerializeField] SpurtBlood playerBlood;
    [SerializeField] SpurtBlood enemyBlood;
    [SerializeField] ParticleSystem explosion;
    private GameObject stationedPlayer;
    private GameObject stationedEnemy;

    [Header("Battle UI")]
    [SerializeField] Canvas battleUI;
    [SerializeField] HealthPips playerHealthPips;
    [SerializeField] GameObject playerSelectionButtons;
    [SerializeField] HealthPips enemyHealthPips;
    [SerializeField] BattleEndPopup battleEndPopup;

    [Header("Only here until animations")]
    [SerializeField] TextMeshProUGUI enemyMoveDisplay;

    [Header("Animation Props")]
    [SerializeField] List<GameObject> props;
    [SerializeField] float throwForce;
    [SerializeField] float torque;

    [Header("Battle Sounds")]
    [SerializeField] AudioSource roundLoseSound;
    [SerializeField] AudioSource roundWinSound;

    private AttackSelection playerAttack;
    private AttackSelection playerBluff = AttackSelection.NULL;
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

    public void SetPlayerBluff(AttackSelection bluff)
    {
        playerBluff = bluff;
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

    public AttackSelection GetPlayerBluff()
    {
        return playerBluff;
    }

    public AttackSelection GetEnemyAttack()
    {
        return enemyAttack;
    }

    public GameObject GetStationedPlayer()
    {
        return stationedPlayer;
    }

    public GameObject GetStationedEnemy()
    {
        return stationedEnemy;
    }

    public Transform GetPlayerThrowPoint()
    {
        return playerThrowPoint;
    }

    public Transform GetEnemyThrowPoint()
    {
        return enemyThrowPoint;
    }

    public void UpdatePlayerHealthUI(int value)
    {
        playerHealthPips.UpdateBar(value);
    }

    public void UpdateEnemyHealthUI(int value)
    {
        enemyHealthPips.UpdateBar(value);
    }

    public void UpdateDisplayedEnemyMove(AttackSelection attack)
    {
        enemyMoveDisplay.text = attack.ToString();
    }

    public void SpurtPlayerBlood()
    {
        playerBlood.Spurt();
    }

    public void SpurtEnemyBlood()
    {
        enemyBlood.Spurt();
    }

    public void Explode()
    {
        explosion.Play();
    }

    public void PlayRoundWinSound()
    {
        roundWinSound.Play();
    }

    public void PlayRoundLostSound()
    {
        roundLoseSound.Play();
    }

    public void ShowButtonSelection()
    {
        playerSelectionButtons.SetActive(true);
    }

    public void Victory()
    {
        battleEndPopup.DisplayVictory();
    }

    public void Defeat()
    {
        battleEndPopup.DisplayDefeat();
    }

    //Why did I make a StartBattleState???
    public void StartBattle(Unit player, Unit enemy)
    {
        Random.InitState((int) Time.time);
        SetPlayer(player);
        SetEnemy(enemy);
        battleUI.gameObject.SetActive(true);
        UpdatePlayerHealthUI(playerUnit.GetHealth());
        UpdateEnemyHealthUI(enemyUnit.GetHealth());
        InstantiateBattleStationCombatants();
        InitializeStateMachine();
        currentState.StateAction();
    }

    public void EndBattle()
    {
        battleUI.gameObject.SetActive(false);
        adventureSystem.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
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
        DestroyEnemyBattleStationCombatant();
        DestroyPlayerBattleStationCombatant();
    }

    public void DestroyEnemyBattleStationCombatant()
    {
        Destroy(enemyBattleStation.transform.GetChild(enemyBattleStation.childCount - 1).gameObject);
    }

    public void DestroyPlayerBattleStationCombatant()
    {
        Destroy(playerBattleStation.transform.GetChild(playerBattleStation.childCount - 1).gameObject);
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

    public void ThrowProp(int index, Transform origin, Vector2 direction)
    {
        Rigidbody2D thrownProp = Instantiate(props[index], origin).GetComponent<Rigidbody2D>();
        thrownProp.AddForce(Vector3.up * throwForce, ForceMode2D.Impulse);
        thrownProp.AddForce(direction, ForceMode2D.Impulse);
        thrownProp.AddTorque(torque, ForceMode2D.Impulse);
    }
}
