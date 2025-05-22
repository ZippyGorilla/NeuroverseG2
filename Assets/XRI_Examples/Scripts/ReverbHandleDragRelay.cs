using UnityEngine;
using UnityEngine.EventSystems;

public class ReverbHandleDragRelay : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public RevCircleController controller;

    public void OnBeginDrag(PointerEventData eventData)
    {
        controller?.ProcessDrag(eventData.position, eventData.pressEventCamera);
    }

    public void OnDrag(PointerEventData eventData)
    {
        controller?.ProcessDrag(eventData.position, eventData.pressEventCamera);
    }
}
