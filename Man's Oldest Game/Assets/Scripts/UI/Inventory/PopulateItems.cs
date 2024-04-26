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

        int child = 0;
        int j = -1;
        foreach(int quantity in playerInventory.itemQuantities)
        {
            j++;
            GameObject childObject;
            Button childButton;
            TextMeshProUGUI childText;
            ButtonIndex buttonIndex;
            if (quantity <= 0)
            {
                continue;
            }
            if (child < transform.childCount) {
                try
                {
                    childObject = transform.GetChild(child).gameObject;
                    childButton = childObject.GetComponent<Button>();
                    buttonIndex = childObject.GetComponent<ButtonIndex>();
                    childText = childObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

                } catch
                {
                    childObject = Instantiate(buttonPrefab, transform);
                    childButton = childObject.GetComponent<Button>();
                    buttonIndex = childObject.GetComponent<ButtonIndex>();
                    childText = childObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                }
            }
            else
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
            child++;
            yield return null;
        }
    }
}
