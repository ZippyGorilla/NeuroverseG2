using UnityEngine;
using UnityEngine.InputSystem;

public class MuteAllAudio : MonoBehaviour
{
    public InputActionReference toggleMuteAction;

    private bool isMuted = false;

    void OnEnable()
    {
        if (toggleMuteAction != null)
        {
            toggleMuteAction.action.performed += ToggleMute;
            toggleMuteAction.action.Enable();
        }
    }

    void OnDisable()
    {
        if (toggleMuteAction != null)
        {
            toggleMuteAction.action.performed -= ToggleMute;
            toggleMuteAction.action.Disable();
        }
    }

    private void ToggleMute(InputAction.CallbackContext context)
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
        Debug.Log($"UnityDebug MuteAllAudio: Muted = {isMuted}");
    }
}