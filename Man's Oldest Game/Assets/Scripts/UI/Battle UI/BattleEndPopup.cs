using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleEndPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endStatus;
    [SerializeField] GameObject victoryButton;
    [SerializeField] GameObject defeatButton;

    public void DisplayVictory()
    {
        gameObject.SetActive(true);
        defeatButton.SetActive(false);
        victoryButton.SetActive(true);
        endStatus.text = "Victory!";
    }

    public void DisplayDefeat()
    {
        gameObject.SetActive(true);
        victoryButton.SetActive(false);
        defeatButton.SetActive(true);
        endStatus.text = "Defeat!";
    }
}
