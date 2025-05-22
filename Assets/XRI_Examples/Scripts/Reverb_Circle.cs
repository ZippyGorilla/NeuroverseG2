using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RevCircleController : MonoBehaviour, IDragHandler, IBeginDragHandler
{

    public RectTransform handle; // draggable object
    public RectTransform circleArea; // the circle container
    public AudioMixer mixer; // your AudioMixer if using Unity's mixer
    public string dryLevelParameter = "dryLevel";
    public string roomParameter = "Room";
    public string decayTimeParameter = "decayTime";

    public float dryWet = -5000f;
    public float decayTime = 1.0f;
    
    public float maxDryWet = 0f;
    public float minDryWet = -10000f;

    public float minDecayTime = 0.5f;
    public float maxDecayTime = 4f;

    Vector2 center;

    void Start()
    {
        center = circleArea.rect.center;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleArea, eventData.position, eventData.pressEventCamera, out localPoint);

        Vector2 offset = localPoint - center;
        float radius = circleArea.rect.width * 0.5f;

        if (offset.magnitude > radius)
            offset = offset.normalized * radius;
        
        handle.anchoredPosition = offset;
        
        float normX = offset.x / radius; // -1 to 1
        float normY = offset.y / radius; // -1 to 1

        decayTime = Mathf.Lerp(minDecayTime, maxDecayTime, (normX+1)/2f);
        dryWet = normY;

        ApplyReverbSettings();
    }
    

    void ApplyReverbSettings()
    {
        //float dryLevel = Mathf.Lerp(maxDryWet, minDryWet, (dryWet+1)/2f);  // Dry in dB
        float room = Mathf.Lerp(minDryWet, maxDryWet, (dryWet+1)/2f);      // Wet in dB

        //mixer.SetFloat(dryLevelParameter, dryLevel);
        mixer.SetFloat(roomParameter, room);
        mixer.SetFloat(decayTimeParameter, decayTime);
    }
}
