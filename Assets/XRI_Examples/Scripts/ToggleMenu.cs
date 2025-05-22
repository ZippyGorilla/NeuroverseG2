using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class XRMenuToggle : MonoBehaviour
{
    public GameObject menuPanel;
    public Button closeButton;

    public InputActionReference toggleMenuAction;

    private void Start()
    {
        if (menuPanel != null)
            menuPanel.SetActive(false); // Hide at start
    }
    
    private void OnEnable()
    {
        toggleMenuAction.action.Enable();
        toggleMenuAction.action.performed += ToggleMenu;
        if (closeButton != null)
            closeButton.onClick.AddListener(CloseMenu);
    }

    private void OnDisable()
    {
        toggleMenuAction.action.performed -= ToggleMenu;
        toggleMenuAction.action.Disable();
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        if (menuPanel != null)
            menuPanel.SetActive(!menuPanel.activeSelf);
    }

    private void CloseMenu()
    {
        if (menuPanel != null)
            menuPanel.SetActive(false);
    }
}