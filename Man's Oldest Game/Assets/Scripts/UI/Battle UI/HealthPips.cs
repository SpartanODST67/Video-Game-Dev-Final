using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPips : MonoBehaviour
{
    [Header("Stored Value")]
    [SerializeField] int value;
    private int cachedValue;
    [Header("Pips")]
    [SerializeField] GameObject pipPrefab;
    public List<GameObject> pips;

    public void UpdateBar(int value)
    {
        this.value = value;
        if(cachedValue != value)
        {
            FillBar();
        }
    }

    public void FillBar()
    {
        foreach (GameObject pip in pips)
        {
            Destroy(pip);
        }
        pips.Clear();
        for (int i = 0; i < value; i++)
        {
            pips.Add(Instantiate(pipPrefab.transform, gameObject.transform).gameObject);
        }
        cachedValue = value;
    }
}
