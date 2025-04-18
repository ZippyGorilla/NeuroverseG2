using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableEQHandle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform handle;
    public RectTransform circleArea; // parent area
    public float maxDistance = 100f; // max pixels from center

    // Events or references to send EQ values
    public System.Action<float, float> OnEQChanged; // (gain, frequency)

    private Vector2 circleCenter;

    void Start()
    {
        circleCenter = circleArea.rect.center;
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleArea, eventData.position, eventData.pressEventCamera, out Vector2 localPos);

        Vector2 offset = localPos - circleCenter;

        // Clamp to circle
        if (offset.magnitude > maxDistance)
            offset = offset.normalized * maxDistance;

        handle.localPosition = offset;

        // Normalize -1 to 1
        Vector2 norm = offset / maxDistance;

        float gain = norm.x; // left/right
        float frequency = norm.y; // up/down

        // Send to EQ system
        OnEQChanged?.Invoke(gain, frequency);
    }

    public void OnEndDrag(PointerEventData eventData) { }
}
