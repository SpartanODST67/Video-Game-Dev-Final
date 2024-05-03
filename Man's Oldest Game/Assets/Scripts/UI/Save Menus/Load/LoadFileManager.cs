using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFileManager : MonoBehaviour
{
    [Header("Button prefab for save files")]
    [SerializeField] GameObject loadButtonPrefab;
    [Header("Confirmation Screen")]
    [SerializeField] LoadConfirmation confirmationScript;
    [Header("Transition")]
    [SerializeField] SnapClose transitionFX;

    private void OnEnable()
    {
        transitionFX.gameObject.SetActive(true);
        string[] saveFiles = SaveSystem.instance.GetSavedGames();
        StartCoroutine(PopulateSavedGames(saveFiles));
    }

    IEnumerator PopulateSavedGames(string[] saveFiles)
    {
        for(int i = transform.childCount - 1; i > -1; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
            yield return null;
        }

        if(saveFiles != null)
        {
            foreach(string file in saveFiles)
            {
                LoadSaveFile newButton = Instantiate(loadButtonPrefab, transform).GetComponent<LoadSaveFile>();
                string[] fileNameSplit = file.Split("/");
                string fileName = fileNameSplit[fileNameSplit.Length - 1];
                newButton.SetFileName(fileName);
                newButton.GetButton().onClick.AddListener(() =>
                {
                    SaveSystem.instance.SetFileName(fileName);
                    confirmationScript.SetLoadFile(newButton.fileName);
                    confirmationScript.gameObject.SetActive(true);
                });
            }
        }
        transitionFX.Snap();
    }
}
