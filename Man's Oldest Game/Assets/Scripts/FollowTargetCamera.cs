using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] GameObject target;
    [Header("Stats")]
    [SerializeField] float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), speed);
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
