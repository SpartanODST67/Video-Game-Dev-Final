using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTransform : MonoBehaviour
{
    [Header("Types of Transform")]
    [SerializeField] bool lockPosition;
    [SerializeField] bool lockRotation;
    [SerializeField] bool lockScale;
    private Vector3 position;
    private Quaternion rotation;
    private Vector3 scale;

    [Header("Local or World Transform")]
    [SerializeField] bool lockLocal;
    [SerializeField] bool lockWorld;

    private void OnEnable()
    {
        if (lockLocal)
        {
            position = transform.localPosition;
            rotation = transform.localRotation;
            scale = transform.localScale;
        }
        else if (lockWorld) 
        {
            position = transform.position;
            rotation = transform.rotation;
            scale = transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lockLocal)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            transform.localScale = scale;
        }
        else if(lockWorld)
        {
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = scale;
        }
    }
}
