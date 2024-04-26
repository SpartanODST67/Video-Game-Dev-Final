using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemQuantity;
    [SerializeField] TextMeshProUGUI itemDescription;

    public void SetItemName(string name)
    {
        itemName.text = name;
    }

    public void SetItemQuantity(string quantity)
    {
        itemQuantity.text = quantity;
    }

    public void SetItemQuantity(int quantity)
    {
        itemQuantity.text = quantity.ToString();
    }

    public void SetItemDescription(string description)
    {
        itemDescription.text = description;
    }
}
