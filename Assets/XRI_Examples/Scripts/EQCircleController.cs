using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EQCircleController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI[] labels;
    [SerializeField] Vector2[] labelDirections;
    [SerializeField] float hoverThreshold = 0.6f;

    Color normalColor = Color.black;
    Color hoverColor = Color.white;

    private Vector3[] currentScales;
    private Vector3[] targetScales;
    private const float scaleSpeed = 5f;

    public RectTransform circleArea;
    public RectTransform handle;
    public Button resetButton;
    public AudioMixer mixer;
    public string gainParameter = "Gain";
    public string frequencyParameter = "Frequency";

    public float maxGain = 3f;
    public float minGain = 0.05f;
    public float minFreq = 20f;
    public float maxFreq = 8000f;

    private Vector2 center;

    private float targetGain = 1f;
    private float targetFreq = 8000f;
    private float currentGain;
    private float currentFreq;

    private float gainVelocity;
    private float freqVelocity;

    public float smoothTime = 0.1f; // Time to smooth toward target values

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

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetEQSettings);
        }

        currentGain = targetGain;
        currentFreq = targetFreq;
    }

    void Update()
    {
        currentGain = Mathf.SmoothDamp(currentGain, targetGain, ref gainVelocity, smoothTime);
        currentFreq = Mathf.SmoothDamp(currentFreq, targetFreq, ref freqVelocity, smoothTime);

        mixer.SetFloat(gainParameter, currentGain);
        mixer.SetFloat(frequencyParameter, currentFreq);
    }

    public void ProcessDrag(Vector2 screenPosition, Camera eventCamera)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleArea, screenPosition, eventCamera, out localPoint);

        Vector2 offset = localPoint - center;
        float radius = circleArea.rect.width * 0.5f;

        if (offset.magnitude > radius)
            offset = offset.normalized * radius;

        handle.anchoredPosition = offset;

        float normX = offset.x / radius;
        float normY = offset.y / radius;

        SetTargetEQ(normX, normY);
    }

    void SetTargetEQ(float x, float y)
    {
        targetGain = Mathf.Lerp(minGain, maxGain, (x + 1) / 2f);

        float logMin = Mathf.Log10(minFreq);
        float logMax = Mathf.Log10(maxFreq);
        float logFreq = Mathf.Lerp(logMin, logMax, (y + 1f) / 2f);
        targetFreq = Mathf.Pow(10f, logFreq);

        //UpdateLabelVisuals(new Vector2(x, y));

        Debug.Log($"UnityDebug EQ (Smoothed): Gain:{targetGain}dB, Freq:{targetFreq}Hz");
    }

    //void UpdateLabelVisuals(Vector2 handlePos)
    //{
    //    for (int i = 0; i < labels.Length; i++)
    //    {
    //        float proximity = Vector2.Dot(handlePos.normalized, labelDirections[i]);
    //        float t = Mathf.InverseLerp(hoverThreshold, 1f, proximity);
//
    //        labels[i].color = Color.Lerp(normalColor, hoverColor, t);
    //        targetScales[i] = Vector3.Lerp(Vector3.one * 0.2f, Vector3.one * 1.1f, t);
    //        currentScales[i] = Vector3.Lerp(currentScales[i], targetScales[i], Time.deltaTime * scaleSpeed);
    //        labels[i].transform.localScale = currentScales[i];
    //    }
    //}

    public void ResetEQSettings()
    {
        handle.anchoredPosition = Vector2.zero;
        SetTargetEQ(-0.36f, 0f); // Reset to neutral values
    }
}
