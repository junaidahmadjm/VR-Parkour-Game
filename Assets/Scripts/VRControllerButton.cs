using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRControllerButton : MonoBehaviour
{
    public InputAction WayFindingPanelButton;
    public GameObject WayFindingPanel;

    private void OnEnable()
    {
        if (WayFindingPanelButton!=null)
        {
            WayFindingPanelButton.Enable();
            WayFindingPanelButton.performed += OnButtonPressed;
        }
    }
    private void OnDisable()
    {
        if (WayFindingPanelButton != null)
        {
            WayFindingPanelButton.Disable();
            WayFindingPanelButton.performed -= OnButtonPressed;
        }
    }

    void OnButtonPressed(InputAction.CallbackContext context)
    {
        WayFindingPanel.SetActive(!WayFindingPanel.activeSelf);
    }
}
