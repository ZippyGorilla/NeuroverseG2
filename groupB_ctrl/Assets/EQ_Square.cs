using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EQSquareController : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public RectTransform handle; // draggable object
    public RectTransform circleArea; // the circle container
    public AudioMixer mixer; // your AudioMixer if using Unity's mixer
    public string gainParameter = "Gain";
    public string frequencyParameter = "Frequency";

    public float maxGain = 3f;
    public float minGain = 0.05f;

    public float minFreq = 0f;
    public float maxFreq = 10000f;

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
        float radius = circleArea.rect.width;

        if (offset.magnitude > radius)
            offset = offset.normalized * radius;
        
        handle.anchoredPosition = offset;
        
        float normX = offset.x / radius; // -1 to 1
        float normY = offset.y / radius; // -1 to 1

        ApplyEQ(normX, normY);
    }

    void ApplyEQ(float x, float y)
    {
        // Gain mapping
        float gain = Mathf.Lerp(minGain, maxGain, (x + 1) / 2f);
        float freq = Mathf.Lerp(minFreq, maxFreq, (y + 1) / 2f);

        mixer.SetFloat(gainParameter, gain);
        mixer.SetFloat(frequencyParameter, freq);

        Debug.Log($"Gain: {gain} dB, Frequency: {freq} Hz");
    }
}
