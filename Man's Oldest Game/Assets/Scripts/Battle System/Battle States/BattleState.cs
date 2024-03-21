using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BattleState
{
    public void SetBattleSystem(BattleSystem battleSystem);
    public void StateAction();
}
