using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIndex : MonoBehaviour
{
    public int index;

    private void OnDisable()
    {
        index = -1;
    }
}
