using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Current Character")]
    [SerializeField] ControllableCharacter controlledCharacter;
    [Header("Pause Menu")]
    [SerializeField] GameObject pauseMenu;
    [Header("Controls")]
    [SerializeField] Controls playerControls;
    public bool isGamePaused { get; private set; } = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Time.timeScale = 1;
                isGamePaused = false;
                pauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                isGamePaused = true;
                pauseMenu.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGamePaused)
        {
            return;
        }

        float verticalInput = 0;
        float horizontalInput = 0;

        if (Input.GetKey(playerControls.Keys[(int)ControlKeys.UP]))
            verticalInput = 1;

        if (Input.GetKey(playerControls.Keys[(int)ControlKeys.DOWN]))
            verticalInput = -1;

        if (Input.GetKey(playerControls.Keys[(int)ControlKeys.LEFT]))
            horizontalInput = -1;

        if (Input.GetKey(playerControls.Keys[(int) ControlKeys.RIGHT]))
            horizontalInput = 1;

        float extraInput = 0; //I'm sure I'm gonna need a 3rd input.
        Vector3 inputVector = new Vector3(horizontalInput, verticalInput, extraInput);

        controlledCharacter.move(inputVector);
    }
}
