using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PitchController : MonoBehaviour
{
    public AudioMixer mixer;

    [Header("Sliders")]
    public Slider pitchSlider;

    [Header("Mixer Parameters")]
    public string pitchParam = "pitchAmount";

    [Header("Ranges")]
    public float minPitch = 0.5f;
    public float maxPitch = 2f;

    [Header("Reset Button")]
    public Button resetButton;

    [Header("Smoothing")]
    public float smoothingTime = 0.2f;

    private float targetPitch = 1f;
    private float smoothedPitch = 1f;
    private float pitchVelocity = 0f;

    void Start()
    {
        pitchSlider.onValueChanged.AddListener(OnSliderChanged);

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetPitch);
        }

        // Initialize with slider's current value
        OnSliderChanged(pitchSlider.value);
    }

    void Update()
    {
        // Smoothly interpolate the pitch value
        smoothedPitch = Mathf.SmoothDamp(smoothedPitch, targetPitch, ref pitchVelocity, smoothingTime);
    }

    public void OnSliderChanged(float value)
    {
        // Convert slider value (0-1) to pitch range
        targetPitch = Mathf.Lerp(minPitch, maxPitch, value);

        mixer.SetFloat(pitchParam, smoothedPitch);
        Debug.Log("UnityDebug PitchShift_" + pitchSlider.name + ": " + value + "x");
    }

    private void ResetPitch()
    {
        float defaultSliderValue = 0.33f;
        pitchSlider.SetValueWithoutNotify(defaultSliderValue);
        OnSliderChanged(defaultSliderValue);

        Debug.Log("UnityDebug PitchShift_" + pitchSlider.name + ": Reseted");
    }
}
