using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBattleState : BattleState
{
    private BattleSystem battleSystem;
    private Unit player;
    private Unit enemy;

    public void SetBattleSystem(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public void StateAction()
    {
        player = battleSystem.GetPlayer();
        enemy = battleSystem.GetEnemy();
        DetermineRound();
        DetermineMatch();
    }

    private void DetermineRound()
    {
        AttackSelection playerAttack = battleSystem.GetPlayerAttack();
        AttackSelection enemyAttack = battleSystem.GetEnemyAttack();
        if (playerAttack == AttackSelection.GUN)
        {
            battleSystem.ThrowProp((int)AttackSelection.GUN, battleSystem.GetPlayerThrowPoint(), Vector2.right);
            PlayerRound();
        }
        else if (playerAttack == AttackSelection.DYNAMITE)
        {
            battleSystem.ThrowProp((int)AttackSelection.DYNAMITE, battleSystem.GetPlayerThrowPoint(), Vector2.right);
            DynamiteRound();
        }
        else if (playerAttack == AttackSelection.ROCK)
        {
            battleSystem.ThrowProp((int)AttackSelection.ROCK, battleSystem.GetPlayerThrowPoint(), Vector2.right);
            if (enemyAttack == AttackSelection.PAPER)
            {
                EnemyRound();
            }
            else if (enemyAttack == AttackSelection.SCISSORS)
            {
                PlayerRound();
            }
            else
            {
                Debug.Log("Tied Round");
            }
        }
        else if (playerAttack == AttackSelection.PAPER)
        {
            battleSystem.ThrowProp((int)AttackSelection.PAPER, battleSystem.GetPlayerThrowPoint(), Vector2.right);
            if (enemyAttack == AttackSelection.SCISSORS)
            {
                EnemyRound();
            }
            else if (enemyAttack == AttackSelection.ROCK)
            {
                PlayerRound();
            }
            else
            {
                Debug.Log("Tied Round");
            }
        }
        else if (playerAttack == AttackSelection.SCISSORS)
        {
            battleSystem.ThrowProp((int)AttackSelection.SCISSORS, battleSystem.GetPlayerThrowPoint(), Vector2.right);
            if (enemyAttack == AttackSelection.ROCK)
            {
                EnemyRound();
            }
            else if (enemyAttack == AttackSelection.PAPER)
            {
                PlayerRound();
            }
            else
            {
                Debug.Log("Tied Round");
            }
        }
    }

    private void EnemyRound()
    {
        Debug.Log("Enemy Wins Round");
        player.TakeDamage(1);
        battleSystem.UpdatePlayerHealthUI(player.GetHealth());
    }

    private void PlayerRound()
    {
        Debug.Log("Player Wins Round");
        enemy.TakeDamage(1);
        battleSystem.UpdateEnemyHealthUI(enemy.GetHealth());
    }

    private void PlayerRound(int damage)
    {
        Debug.Log("Player Wins Round");
        enemy.TakeDamage(damage);
        battleSystem.UpdateEnemyHealthUI(enemy.GetHealth());
    }

    private void DynamiteRound()
    {
        Debug.Log("BOOM!");
        enemy.TakeDamage(9999);
        battleSystem.UpdateEnemyHealthUI(enemy.GetHealth());
        player.TakeDamage(1);
    }

    private void DetermineMatch()
    {
        if(player.GetHealth() <= 0)
        {
            Debug.Log("Player Loss");
            battleSystem.SetState(battleSystem.GetState(4));
            battleSystem.TriggerState();
        }
        else if(enemy.GetHealth() <= 0)
        {
            Debug.Log("Player Victory");
            battleSystem.SetState(battleSystem.GetState(5));
            battleSystem.TriggerState();
        }
        else
        {
            Debug.Log("Continuing Battle");
            battleSystem.SetState(battleSystem.GetState(1));
            battleSystem.TriggerState();
        }
    }
}
