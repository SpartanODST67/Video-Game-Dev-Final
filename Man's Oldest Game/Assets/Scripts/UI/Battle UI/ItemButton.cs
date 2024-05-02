using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] int itemID;
    [SerializeField] Inventory playerInventory;

    // Update is called once per frame
    void Update()
    {
        if (playerInventory.itemQuantities[itemID] <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void RemoveItem()
    {
        playerInventory.itemQuantities[itemID]--;
    }
}
