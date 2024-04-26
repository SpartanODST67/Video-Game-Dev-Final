using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscardButton : MonoBehaviour
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] Button myself;
    [SerializeField] GameObject refreshInventory;
    [SerializeField] GameObject detailsPage;
    [SerializeField] GameObject discardNotification;
    private int discardTarget;

    public void UpdateDiscardButton(int target)
    {
        discardTarget = target;
        myself.onClick.RemoveAllListeners();
        myself.onClick.AddListener(() =>
        {
            playerInventory.itemQuantities[discardTarget]--;
            detailsPage.SetActive(false);
            refreshInventory.SetActive(false);
            refreshInventory.SetActive(true);
            discardNotification.SetActive(true);
        });
    }

    public void SetDiscardTarget(int index)
    {
        discardTarget = index;
    }
}
