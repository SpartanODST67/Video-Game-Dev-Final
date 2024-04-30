using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlKeys { UP, DOWN, LEFT, RIGHT, ROCK, PAPER, SCISSORS}

[CreateAssetMenu(menuName = "ScriptableObjects/Controls")]
public class Controls : ScriptableObject
{
    public List<KeyCode> Keys = new List<KeyCode>();

    public void SetKeys(List<KeyCode> newKeys)
    {
        Keys = newKeys;
    }
}
