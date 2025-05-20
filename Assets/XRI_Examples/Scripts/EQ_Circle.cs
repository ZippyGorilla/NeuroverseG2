using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EQCircleController : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    
    [SerializeField] TMPro.TextMeshProUGUI[] labels;
    [SerializeField] Vector2[] labelDirections; // matching label order
    [SerializeField] float hoverThreshold = 0.6f;
    
    [SerializeField] Image[] glowSegments; // same count/order as labels
    
    Color normalColor = Color.black;
    Color hoverColor = Color.white;

    private Vector3[] currentScales;
    private Vector3[] targetScales;
    private const float scaleSpeed = 5f;


    public RectTransform handle; // draggable object
    public RectTransform circleArea; // the circle container
    public AudioMixer mixer; // your AudioMixer if using Unity's mixer
    public string gainParameter = "Gain";
    public string frequencyParameter = "Frequency";

    public float maxGain = 3f;
    public float minGain = 0.05f;

    public float minFreq = 20f;
    public float maxFreq = 8000f;

    Vector2 center;

    void Start()
    {
        center = circleArea.rect.center;

        currentScales = new Vector3[labels.Length];
        targetScales = new Vector3[labels.Length];

        for (int i = 0; i < labels.Length; i++)
        {
            currentScales[i] = Vector3.one;
            targetScales[i] = Vector3.one;
        }

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

        ApplyEQ(normX, normY);
    }
    

    void UpdateLabelVisuals(Vector2 handlePos)
    {
        for (int i = 0; i < labels.Length; i++)
        {
            float proximity = Vector2.Dot(handlePos.normalized, labelDirections[i]);
            float t = Mathf.InverseLerp(hoverThreshold, 1f, proximity);

            labels[i].color = Color.Lerp(normalColor, hoverColor, t);
            targetScales[i] = Vector3.Lerp(Vector3.one * 0.2f, Vector3.one * 1.1f, t);
            
            currentScales[i] = Vector3.Lerp(currentScales[i], targetScales[i], Time.deltaTime * scaleSpeed);
            labels[i].transform.localScale = currentScales[i];
            
            //glowSegments[i].color = new Color(1f, 0.5f, 0.5f, t * 0.8f); // subtle red glow
        }
    }

    void ApplyEQ(float x, float y)
    {
        // Gain mapping
        float gain = Mathf.Lerp(minGain, maxGain, (x + 1) / 2f);
        // CFreq mapping
        float logMin = Mathf.Log10(minFreq);
        float logMax = Mathf.Log10(maxFreq);
        float logFreq = Mathf.Lerp(logMin, logMax, (y + 1f) / 2f);
        float freq = Mathf.Pow(10f, logFreq);

        mixer.SetFloat(gainParameter, gain);
        mixer.SetFloat(frequencyParameter, freq);

        UpdateLabelVisuals(new Vector2(x, y));

        Debug.Log("UnityDebug EQ: " + $"Gain:{gain}dB,Frequency:{freq}Hz,x:{x},y:{y}");
    }
}
