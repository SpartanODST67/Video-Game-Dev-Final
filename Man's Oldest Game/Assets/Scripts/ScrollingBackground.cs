using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float loopPoint;
    [SerializeField] Vector3 origin;

    private void Start()
    {
        origin = transform.position;
        Debug.Log(origin.y + loopPoint);
    }

    private void Update()
    {
        if(transform.position.y <= origin.y + loopPoint)
        {
            transform.position = origin;
        }

        transform.position += transform.up * speed * Time.deltaTime;
    }
}
