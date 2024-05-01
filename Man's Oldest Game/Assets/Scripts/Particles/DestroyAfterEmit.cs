using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterEmit : MonoBehaviour
{
    [SerializeField] ParticleSystem myself;
    [SerializeField] bool destroy = false;
    [SerializeField] bool disable = true;
    private bool destroyable = false;

    private void Update()
    {
        if(myself.isStopped)
        {
            if(destroy)
            {
                Destroy(myself.gameObject);
            }
            if(disable)
            {
                myself.gameObject.SetActive(false);
            }
        }
    }
}
