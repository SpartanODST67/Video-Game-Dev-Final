using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLookDirection : MonoBehaviour
{
    [SerializeField] bool right;

    public void ForceDirection()
    {
        GameObject child = transform.GetChild(transform.childCount - 1).gameObject;

        float direction = Mathf.Abs(child.transform.localScale.x);
        if(!right)
        {
            direction *= -1;
        }

        child.transform.localScale = new Vector3(direction, child.transform.localScale.y, child.transform.localScale.z);
    }
}
