using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChildrenOnDisable : MonoBehaviour
{
    private void OnDisable()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }
}
