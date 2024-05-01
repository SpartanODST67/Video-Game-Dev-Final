using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] bool emitOnEnable = false;
    [SerializeField] bool emitOnDisable = false;

    private void OnEnable()
    {
        if(emitOnEnable)
        {
            Emit();
        }
    }

    private void OnDisable()
    {
        if(emitOnDisable)
        {
            Emit();
        }
    }

    public void Emit()
    {
        Debug.Log("Emitting");
        particle.Play();
    }
}
