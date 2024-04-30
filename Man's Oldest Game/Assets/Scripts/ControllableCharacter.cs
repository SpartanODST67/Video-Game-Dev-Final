using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class ControllableCharacter : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float speed = 5f;
    [Header("Animation")]
    [SerializeField] AnimationStateChanger animationStateChanger;

    public void move(Vector3 inputVector)
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.position += new Vector3(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime);
        
        if(inputVector.x != 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * inputVector.x, transform.localScale.y, transform.localScale.z);
        }

        animationStateChanger.ChangeAnimationState(inputVector);
    }
}
