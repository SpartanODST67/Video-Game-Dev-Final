using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Item Details")]
    public int itemID;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [Header("Inventory Reference")]
    [SerializeField] Inventory playerInventory;

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemDescription()
    {
        return itemDescription;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInventory.AddItemQuantity(itemID);
            Destroy(gameObject);
        }
    }

    protected abstract void UseItem();
}
