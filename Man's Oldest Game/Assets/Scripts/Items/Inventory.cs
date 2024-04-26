using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemDictionary = new List<Item>();
    public List<int> itemQuantities = new List<int>();

    public void AddItemQuantity(int index)
    {
        itemQuantities[index]++;
    }

    public void AddItemQuantity(int index, int amount)
    {
        itemQuantities[index] += amount;
    }

    public void InitializeItemQuantities()
    {
        itemQuantities = new List<int>(itemDictionary.Count);
    }
}
