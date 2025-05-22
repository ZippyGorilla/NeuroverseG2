using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRUIHapticsBothHands : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [System.Obsolete]
    public XRBaseController controller; // Assign in inspector (e.g., right controller)

    [Range(0f, 1f)] public float hoverIntensity = 0.2f;
    [Range(0f, 1f)] public float clickIntensity = 0.5f;
    public float duration = 0.1f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SendHaptic(hoverIntensity);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SendHaptic(clickIntensity);
    }

    void SendHaptic(float amplitude)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(amplitude, duration);
        }
    }
}
