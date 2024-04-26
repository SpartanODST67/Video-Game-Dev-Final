using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [Header("Saved Items")]
    [SerializeField] string sceneName;
    [SerializeField] Inventory playerInventory;

    [Header("Save Location")]
    [SerializeField] string fileName;
    [SerializeField] string folderPath = "./Saves/";
    public static SaveSystem instance { get; private set; }

    private void Awake()
    {
        Singleton();
        DontDestroyOnLoad(gameObject);
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void SetSceneName(string sceneName)
    {
        this.sceneName = sceneName;
    }

    public string GetSceneName()
    {
        return sceneName;
    }

    public void SetFileName(string fileName)
    {
        this.fileName = fileName;
    }

    public void SaveGame()
    {
        StringBuilder path = new StringBuilder(folderPath);
        path.Append(fileName);

        string filePath = path.ToString();
        string inventorySave = playerInventory.ToCSV();

        StringBuilder saveData = new StringBuilder(sceneName);
        saveData.Append("\n");
        saveData.Append(inventorySave);

        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        try
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(saveData.ToString());
            }
        } catch (Exception e)
        {
            throw e;
        }
    }

    //Returns 0 on successful load, -1 if directory does not exists, and -2 if file does not exist
    public int LoadGame()
    {
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            return -1;
        }

        StringBuilder path = new StringBuilder(folderPath);
        path.Append(fileName);

        string filePath = path.ToString();

        if(!File.Exists(filePath))
        {
            return -2;
        }

        StreamReader sr = File.OpenText(filePath);
        sceneName = sr.ReadLine();
        playerInventory.FromCSV(sr.ReadLine());
        return 0;
    }

    public string[] GetSavedGames()
    {
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            return null;
        }
        return Directory.GetFiles(folderPath);
    }

    public int CountSavedGames()
    {
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            return 0;
        }
        return Directory.GetFiles(folderPath).Length;
    }
}
