using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlSettingsMenu : MonoBehaviour
{
    [Header("Control Scriptable Object")]
    [SerializeField] Controls playerControls;
    [SerializeField] List<KeyCode> defaultControls = new List<KeyCode>();

    [Header("Control")]
    [SerializeField] TMP_Dropdown upDropdown;
    [SerializeField] TMP_Dropdown downDropdown;
    [SerializeField] TMP_Dropdown leftDropdown;
    [SerializeField] TMP_Dropdown rightDropdown;
    [SerializeField] TMP_Dropdown rockDropdown;
    [SerializeField] TMP_Dropdown paperDropdown;
    [SerializeField] TMP_Dropdown scissorsDropdown;

    private ControlKeys changedControl;

    //I would fire myself if I saw this.
    public List<KeyCode> keys = new List<KeyCode> { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};


    private void OnEnable()
    {
        GetKeyOptions();
        SetActiveOptions();
    }

    private void GetKeyOptions()
    {
        upDropdown.ClearOptions();
        downDropdown.ClearOptions();
        leftDropdown.ClearOptions();
        rightDropdown.ClearOptions();
        rockDropdown.ClearOptions();
        paperDropdown.ClearOptions();
        scissorsDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        for(int i = 0; i < keys.Count; i++)
        {
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(keys[i].ToString());
            options.Add(newOption);
        }

        upDropdown.AddOptions(options);
        downDropdown.AddOptions(options);
        leftDropdown.AddOptions(options);
        rightDropdown.AddOptions(options);
        rockDropdown.AddOptions(options);
        paperDropdown.AddOptions(options);
        scissorsDropdown.AddOptions(options);
    }

    private void SetActiveOptions()
    {
        upDropdown.value = FindIndex(playerControls.Keys[(int)ControlKeys.UP]);
        downDropdown.value = FindIndex(playerControls.Keys[(int)ControlKeys.DOWN]);
        leftDropdown.value = FindIndex(playerControls.Keys[(int)ControlKeys.LEFT]);
        rightDropdown.value = FindIndex(playerControls.Keys[(int)ControlKeys.RIGHT]);
        rockDropdown.value = FindIndex(playerControls.Keys[(int)ControlKeys.ROCK]);
        paperDropdown.value = FindIndex(playerControls.Keys[(int)ControlKeys.PAPER]);
        scissorsDropdown.value = FindIndex(playerControls.Keys[(int)ControlKeys.SICSSORS]);
    }

    private int FindIndex(KeyCode key)
    {
        for(int i = 0; i < keys.Count; i++)
        {
            if (keys[i].Equals(key))
                return i;
        }
        return 0;
    }

    public void ChooseControl(ControlKeys control, KeyCode key)
    {
        playerControls.Keys[(int)control] = key;
    }

    public void SetChangedControl(ControlKeys control)
    {
        changedControl = control;
    }

    public void SetChangedControl(int control)
    {
        changedControl = (ControlKeys) control;
    }

    public void ChangeControl(KeyCode key)
    {
        playerControls.Keys[(int)changedControl] = key;
    }

    public void ChangeControl()
    {
        switch (changedControl)
        {
            case ControlKeys.UP:
                playerControls.Keys[(int)changedControl] = keys[upDropdown.value];
                break;
            case ControlKeys.DOWN:
                playerControls.Keys[(int)changedControl] = keys[downDropdown.value];
                break;
            case ControlKeys.LEFT:
                playerControls.Keys[(int)changedControl] = keys[leftDropdown.value];
                break;
            case ControlKeys.RIGHT:
                playerControls.Keys[(int)changedControl] = keys[rightDropdown.value];
                break;
            case ControlKeys.ROCK:
                playerControls.Keys[(int)changedControl] = keys[rockDropdown.value];
                break;
            case ControlKeys.PAPER:
                playerControls.Keys[(int)changedControl] = keys[paperDropdown.value];
                break;
            case ControlKeys.SICSSORS:
                playerControls.Keys[(int)changedControl] = keys[scissorsDropdown.value];
                break;
        }
    }

    public void ResetControls()
    {
        Debug.Log("Resetting Controls");
        playerControls.SetKeys(defaultControls);
        Debug.Log("Controls Reset");
        SetActiveOptions();
        Debug.Log("Controls Visually Reset");
    }
}