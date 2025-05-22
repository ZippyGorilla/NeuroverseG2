using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RevCircleController : MonoBehaviour
{
    public RectTransform handle; // draggable object
    public RectTransform circleArea; // the circle container
    public AudioMixer mixer;
    public Button resetButton;

    public string roomParameter = "Room";
    public string decayTimeParameter = "decayTime";

    public float maxDryWet = 0f;
    public float minDryWet = -10000f;

    public float minDecayTime = 0.1f;
    public float maxDecayTime = 4f;

    Vector2 center;

    // Smoothing variables
    private float targetRoom = -10000f;
    private float smoothedRoom;
    private float roomVelocity;

    private float targetDecay = 0.1f;
    private float smoothedDecay;
    private float decayVelocity;

    public float smoothingTime = 0.2f;

    void Start()
    {
        center = circleArea.rect.center;

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetRevSettings);
        }

        // Initialize smoothed values
        smoothedRoom = targetRoom;
        smoothedDecay = targetDecay;
    }

    void Update()
    {
        // Smoothly interpolate room and decayTime
        smoothedRoom = Mathf.SmoothDamp(smoothedRoom, targetRoom, ref roomVelocity, smoothingTime);
        smoothedDecay = Mathf.SmoothDamp(smoothedDecay, targetDecay, ref decayVelocity, smoothingTime);

        mixer.SetFloat(roomParameter, smoothedRoom);
        mixer.SetFloat(decayTimeParameter, smoothedDecay);
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

        float normX = offset.x / radius; // -1 to 1
        float normY = offset.y / radius; // -1 to 1

        SetTargetReverb(normX, normY);
    }

    void SetTargetReverb(float x, float y)
    {
        targetRoom = Mathf.Lerp(minDryWet, maxDryWet, (y + 1f) / 2f);
        targetDecay = Mathf.Lerp(minDecayTime, maxDecayTime, (x + 1f) / 2f);
    }

    private void ResetRevSettings()
    {
        handle.anchoredPosition = Vector2.zero;
        SetTargetReverb(-1f, -1f); // Bottom-left of the circle
    }
}
