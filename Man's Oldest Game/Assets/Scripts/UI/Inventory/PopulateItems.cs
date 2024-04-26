using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class PopulateItems : MonoBehaviour
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] DetailMenu detailMenu;

    private void OnEnable()
    {
        StartCoroutine(PopulateItemsCoroutine());
    }

    IEnumerator PopulateItemsCoroutine()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            yield return null;
        }

        int j = -1;
        foreach(int quantity in playerInventory.itemQuantities)
        {
            j++;
            bool childFound = false;
            GameObject childObject = null;
            Button childButton = null;
            TextMeshProUGUI childText = null;
            ButtonIndex buttonIndex = null;

            if (quantity <= 0)
            {
                continue;
            }

            for(int i = 0; i < transform.childCount; i++)
            {
                if(childFound)
                {
                    break;
                }

                try
                {
                    childObject = transform.GetChild(i).gameObject;
                    Debug.Log(childObject.name);
                    childButton = childObject.GetComponent<Button>();
                    buttonIndex = childObject.GetComponent<ButtonIndex>();
                    if(buttonIndex.index != -1)
                    {
                        throw new Exception("Button Already Used.");
                    }
                    childText = childObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    childObject.gameObject.SetActive(true);
                    childFound = true;
                } catch (Exception e)
                {
                    Debug.LogWarning(e.Message);
                    childFound = false;
                }
            }

            if(!childFound)
            {
                childObject = Instantiate(buttonPrefab, transform);
                childButton = childObject.GetComponent<Button>();
                buttonIndex = childObject.GetComponent<ButtonIndex>();
                childText = childObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            }

            buttonIndex.index = j;
            childText.text = playerInventory.itemDictionary[j].GetItemName();
            childButton.onClick.RemoveAllListeners();
            childButton.onClick.AddListener(() =>
            {
                detailMenu.SetItemName(playerInventory.itemDictionary[buttonIndex.index].GetItemName());
                detailMenu.SetItemDescription(playerInventory.itemDictionary[buttonIndex.index].GetItemDescription());
                detailMenu.SetItemQuantity(playerInventory.itemQuantities[buttonIndex.index]);
                detailMenu.gameObject.SetActive(true);
            });

            yield return null;
        }
    }
}
