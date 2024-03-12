using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class ControllableCharacter : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    public void move(Vector3 inputVector)
    {
        transform.position += new Vector3(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime);
    }
}
