using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] Image myself;
    [SerializeField] int fadeRate = 5;
    [Range(0.01f, .99f)]
    [SerializeField] float fadeAmount = 0.1f;

    public void Fade()
    {
        gameObject.SetActive(true);
        if (Time.timeScale != 1)
        {
            StartCoroutine(FadeCoroutineFD());
        }
        else
        {
            StartCoroutine(FadeCoroutineFI());
        }
    }

    //I can't make this framerate independent because timescale would be zero D:
    IEnumerator FadeCoroutineFD()
    {
        int frameCounter = 0;
        while(myself.color.a > 0)
        {
            if (frameCounter % fadeRate == 0)
            {
                myself.color = new Color(myself.color.r, myself.color.g, myself.color.b, myself.color.a - fadeAmount);
            }
            frameCounter++;
            yield return null;
        }
        gameObject.SetActive(false);
        myself.color = new Color(myself.color.r, myself.color.g, myself.color.b, 1);
    }

    IEnumerator FadeCoroutineFI()
    {
        while (myself.color.a > 0)
        {
            myself.color = new Color(myself.color.r, myself.color.g, myself.color.b, myself.color.a - (fadeAmount * Time.deltaTime));
            yield return null;
        }
        gameObject.SetActive(false);
        myself.color = new Color(myself.color.r, myself.color.g, myself.color.b, 1);
    }
}
