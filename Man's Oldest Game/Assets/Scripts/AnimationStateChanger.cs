using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnimationState(Vector3 movementVector)
    {
        string newState = "Idle";
        if(movementVector.x != 0)
        {
            newState = "Walk Side";
        }
        if(movementVector.y > 0)
        {
            newState = "Walk Up";
        }
        if(movementVector.y < 0)
        {
            newState = "Walk Down";
        }
        ChangeAnimationState(newState);
    }

    public void ChangeAnimationState(string newState)
    {
        if(currentState == newState)
        {
            return;
        }

        currentState = newState;
        animator.Play(currentState);
    }
}
