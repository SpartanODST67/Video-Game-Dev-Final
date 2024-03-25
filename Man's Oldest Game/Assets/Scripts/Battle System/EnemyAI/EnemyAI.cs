using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyAI
{
    public AttackSelection MakeDecision();
    public void SetPlayerBluff(AttackSelection bluff);
}
