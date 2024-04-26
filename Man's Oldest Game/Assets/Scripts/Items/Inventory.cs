using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public void InitializeInventory()
    {
        for(int i = 0; i < itemDictionary.Count; i++)
        {
            try
            {
                itemQuantities[i] = 0;
            } catch
            {
                itemQuantities.Add(0);
            }
        }
    }

    public string ToCSV()
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < itemQuantities.Count; i++)
        {
            sb.Append(itemQuantities[i].ToString());
            sb.Append(",");
        }
        sb.Length--;
        return sb.ToString();
    }

    public void FromCSV(string line)
    {
        string[] entries = line.Split(",");
        for(int i = 0; i < entries.Length; i++)
        {
            try
            {
                itemQuantities[i] = int.Parse(entries[i]);
            } catch(Exception e)
            {
                Debug.LogException(e);
                try
                {
                    itemQuantities.Add(int.Parse(entries[i]));
                } catch(Exception f)
                {
                    Debug.LogException(f);
                }
            }
        }
    }
}
