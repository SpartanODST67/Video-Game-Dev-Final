using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] SnapClose transistion;

    private void OnEnable()
    {
        transistion.Snap();
    }

    private void OnDisable()
    {
        transistion.gameObject.SetActive(true);
    }
}
