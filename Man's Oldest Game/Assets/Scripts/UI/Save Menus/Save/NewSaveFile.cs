using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewSaveFile : MonoBehaviour
{
    [Header("Save File")]
    public string fileName;
    [Header("To initialize data")]
    [SerializeField] Inventory playerInventory;
    [Header("To modify button listeners")]
    [SerializeField] Button myButton;
    [Header("For status display")]
    [SerializeField] TextMeshProUGUI statusNotificationText;
    [SerializeField] string successMessage = "Save Successful";
    [SerializeField] string failureMessage = "Save Failed";

    public void SetFileName(string fileName)
    {
        this.fileName = fileName;
    }

    public string GetFileName()
    {
        return fileName;
    }

    public Inventory GetInventory()
    {
        return playerInventory;
    }

    public Button GetButton()
    {
        return myButton;
    }

    public void ShowStatusSuccess()
    {
        statusNotificationText.text = successMessage;
        statusNotificationText.color = Color.white;
        statusNotificationText.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(true);
    }

    public void ShowStatusFailure()
    {
        statusNotificationText.text = failureMessage;
        statusNotificationText.color = Color.red;
        statusNotificationText.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(true);
    }
}
