using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapClose : MonoBehaviour
{
    [SerializeField] RectTransform myself;
    [SerializeField] int closeRate = 2;
    [Range(0.01f, 0.99f)]
    [SerializeField] float closeAmount = 0.1f;

    public void Snap()
    {
        if(Time.timeScale != 1)
        {
            StartCoroutine(SnapCoroutineFD());
        }
        else
        {
            StartCoroutine(SnapCoroutineFI());
        }
    }

    IEnumerator SnapCoroutineFD()
    {
        int frameCounter = 0;
        float storedY = myself.localScale.y;
        while(myself.localScale.y > 0)
        {
            if(frameCounter % closeRate == 0)
            {
                myself.localScale = new Vector3(myself.localScale.x, myself.localScale.y - closeAmount, myself.localScale.z);
            }
            yield return null;
        }
        gameObject.SetActive(false);
        myself.localScale = new Vector3(myself.localScale.x, storedY, myself.localScale.z);
    }

    IEnumerator SnapCoroutineFI()
    {
        float storedY = myself.localScale.y;
        while (myself.localScale.y > 0)
        {
            myself.localScale = new Vector3(myself.localScale.x, myself.localScale.y - (closeAmount * Time.deltaTime), myself.localScale.z);
            yield return null;
        }
        gameObject.SetActive(false);
        myself.localScale = new Vector3(myself.localScale.x, storedY, myself.localScale.z);
    }
}
