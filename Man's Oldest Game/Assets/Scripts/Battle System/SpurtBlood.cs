using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpurtBlood : MonoBehaviour
{
    [SerializeField] ParticleSystem bloodFX;

    public void Spurt()
    {
        bloodFX.Play();
    }
}
