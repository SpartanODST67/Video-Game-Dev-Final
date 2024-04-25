using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitConfirmation : MonoBehaviour
{
    [SerializeField] Button confirmationButton;

    public void QuitToDesktop()
    {
        confirmationButton.onClick.RemoveAllListeners();
        confirmationButton.onClick.AddListener(() =>
        {
            Debug.Log("Quiting Game");
            Application.Quit();
        });
    }

    public void QuitToMainMenu()
    {
        confirmationButton.onClick.RemoveAllListeners();
        confirmationButton.onClick.AddListener(() =>
        {
            Debug.Log("Returning to Main Menu");
            SceneManager.LoadScene("TitleScreen");
        });
    }
}
