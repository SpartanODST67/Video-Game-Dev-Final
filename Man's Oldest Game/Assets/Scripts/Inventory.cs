using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemQuantities = new List<Item>();
}
