using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFileManager : MonoBehaviour
{
    [Header("Button prefab for exsiting save files")]
    [SerializeField] GameObject existingSaveButton;
    [Header("Script for new file button")]
    [SerializeField] NewSaveFile newSaveButton;
    [Header("Status Report")]
    [SerializeField] TextMeshProUGUI saveStatusText;
    [Header("Found Save Files")]
    [SerializeField] List<string> fileNames = new List<string>();
    [Header("Determines if a new game is started when selecting a save file")]
    [SerializeField] bool newGame = false;
    [SerializeField] string startingScene = "SampleScreen";
    [Header("Transition")]
    [SerializeField] SnapClose transitionFX;

    private void OnEnable()
    {
        transitionFX.gameObject.SetActive(true);
        string[] saveFiles = SaveSystem.instance.GetSavedGames();
        StartCoroutine(PopulateSaveFiles(saveFiles));
    }

    IEnumerator PopulateSaveFiles(string[] saveFiles)
    {
        fileNames.Clear();
        for(int i = transform.childCount - 1; i > 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
            yield return null;
        }

        if(saveFiles != null)
        {
            foreach(string file in saveFiles)
            {
                ExistingSaveFile newButton = Instantiate(existingSaveButton, transform).GetComponent<ExistingSaveFile>();
                string[] filePathSplit = file.Split('/');
                string fileName = filePathSplit[filePathSplit.Length - 1];
                fileNames.Add(fileName);
                newButton.SetFileName(fileName);
                newButton.SetStatusNotification(saveStatusText);
                newButton.GetButton().onClick.AddListener(() =>
                {
                    if (!newGame)
                    {
                        SaveSystem.instance.SetFileName(newButton.fileName);
                        SaveSystem.instance.SetSceneName(SceneManager.GetActiveScene().name);
                        try
                        {
                            SaveSystem.instance.SaveGame();
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e);
                            newButton.ShowStatusFailure();
                            return;
                        }
                        newButton.ShowStatusSuccess();
                    }
                    else
                    {
                        newSaveButton.GetInventory().InitializeInventory();
                        try
                        {
                            SaveSystem.instance.SetSceneName(startingScene);
                            SaveSystem.instance.SaveGame();
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e);
                            newSaveButton.ShowStatusFailure();
                            return;
                        }
                        try
                        {
                            SceneManager.LoadScene(startingScene);
                        } catch (Exception e)
                        {
                            Debug.LogException(e);
                            newSaveButton.ShowStatusFailure();
                        }
                    }
                });
                yield return null;
            }
        }

        string newFileName = "file" + fileNames.Count.ToString() + ".csv";
        newSaveButton.SetFileName(newFileName);
        newSaveButton.GetButton().onClick.AddListener(() =>
        {
            if(newGame)
            {
                newSaveButton.GetInventory().InitializeInventory();
            }
            SaveSystem.instance.SetFileName(newSaveButton.GetFileName());
            try
            {
                if(newGame)
                {
                    SaveSystem.instance.SetSceneName(startingScene);
                }
                else
                {
                    SaveSystem.instance.SetSceneName(SceneManager.GetActiveScene().name);
                }
                SaveSystem.instance.SaveGame();
                if (!newGame)
                {
                    newSaveButton.ShowStatusSuccess();
                }
            } catch (Exception e)
            {
                Debug.LogException(e);
                newSaveButton.ShowStatusFailure();
                return;
            }
            if(newGame)
            {
                try
                {
                    SceneManager.LoadScene(startingScene);
                } catch (Exception e) //It's not an exception :(
                {
                    Debug.LogException(e);
                    newSaveButton.ShowStatusFailure();
                }
            }
            else
            {
                gameObject.transform.parent.gameObject.SetActive(false);
                gameObject.transform.parent.gameObject.SetActive(true);
            }
        });
        newSaveButton.gameObject.SetActive(true);
        transitionFX.Snap();
    }
}
