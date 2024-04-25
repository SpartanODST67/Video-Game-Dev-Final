using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Current Character")]
    [SerializeField] ControllableCharacter controlledCharacter;
    [Header("Pause Menu")]
    [SerializeField] GameObject pauseMenu;
    public bool isGamePaused = false;

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
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float extraInput = 0; //I'm sure I'm gonna need a 3rd input.
        Vector3 inputVector = new Vector3(horizontalInput, verticalInput, extraInput);

        controlledCharacter.move(inputVector);
    }
}
