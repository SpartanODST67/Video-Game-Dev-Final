using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] ControllableCharacter controlledCharacter;

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float extraInput = 0; //I'm sure I'm gonna need a 3rd input.
        Vector3 inputVector = new Vector3(horizontalInput, verticalInput, extraInput);

        controlledCharacter.move(inputVector);
    }
}
