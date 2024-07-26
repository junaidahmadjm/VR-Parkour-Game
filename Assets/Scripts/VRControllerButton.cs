using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRControllerButton : MonoBehaviour
{
    public InputAction WayFindingPanelButton;
    public GameObject WayFindingPanel;
    public InputAction MusicPanelButton;
    public GameObject MusicPanel;

    public InputAction HelpPanelButton;
    public GameObject HelpPanel;

    public InputAction SelectionBasedJumpButton;
    public GameObject[] SelectionBasedObjects;

    private void OnEnable()
    {
        if (WayFindingPanelButton!=null)
        {
            WayFindingPanelButton.Enable();
            WayFindingPanelButton.performed += OnButtonPressed;
        }

        if (MusicPanelButton != null)
        {
            MusicPanelButton.Enable();
            MusicPanelButton.performed += OnButtonPressedMusic;
        }

        if (HelpPanelButton != null)
        {
            HelpPanelButton.Enable();
            HelpPanelButton.performed += OnButtonPressedHelp;
        }

        if (SelectionBasedJumpButton != null)
        {
            SelectionBasedJumpButton.Enable();
            SelectionBasedJumpButton.performed += OnButtonPressedSelectionJump;
        }
    }
    private void OnDisable()
    {
        if (WayFindingPanelButton != null)
        {
            WayFindingPanelButton.Disable();
            WayFindingPanelButton.performed -= OnButtonPressed;
        }

        if (MusicPanelButton != null)
        {
            MusicPanelButton.Enable();
            MusicPanelButton.performed -= OnButtonPressedMusic;
        }

        if (HelpPanelButton != null)
        {
            HelpPanelButton.Enable();
            HelpPanelButton.performed -= OnButtonPressedHelp;
        }

        if (SelectionBasedJumpButton != null)
        {
            SelectionBasedJumpButton.Enable();
            SelectionBasedJumpButton.performed -= OnButtonPressedSelectionJump;
        }
    }

    void OnButtonPressed(InputAction.CallbackContext context)
    {
        WayFindingPanel.SetActive(!WayFindingPanel.activeSelf);
    }
    void OnButtonPressedMusic(InputAction.CallbackContext context)
    {
        MusicPanel.SetActive(!MusicPanel.activeSelf);
    }

    void OnButtonPressedHelp(InputAction.CallbackContext context)
    {
        HelpPanel.SetActive(!HelpPanel.activeSelf);
    }

    void OnButtonPressedSelectionJump(InputAction.CallbackContext context)
    {
        foreach (var item in SelectionBasedObjects)
        {
            if (item)
                item.SetActive(true);
        }
    }


}
