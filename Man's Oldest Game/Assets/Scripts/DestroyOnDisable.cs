using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDisable : MonoBehaviour
{
    //This has to be the most hacky way I can do this.
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
