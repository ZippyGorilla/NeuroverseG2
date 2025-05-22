using UnityEngine;
using UnityEngine.EventSystems;

public class EQHandleDragRelay : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public EQCircleController controller;

    public void OnBeginDrag(PointerEventData eventData)
    {
        controller?.ProcessDrag(eventData.position, eventData.pressEventCamera);
    }

    public void OnDrag(PointerEventData eventData)
    {
        controller?.ProcessDrag(eventData.position, eventData.pressEventCamera);
    }
}
