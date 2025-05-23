using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SaturationController : MonoBehaviour
{
    public Slider fxSlider;
    public AudioMixer mixer;

    [Header("Mixer Parameters")]
    public string distortionParam = "DistortionAmount";
    public string highpassParam = "HighpassCutoff";
    public string duckVolumeParam = "DuckVolume";

    [Header("Reset Button")]
    public Button resetButton;

    [Header("Ranges")]
    public float minDistortion = 0f;
    public float maxDistortion = 0.9f;

    public float minCutoff = 10f;
    public float maxCutoff = 10000f;

    public float minVolume = 0f;      // 0 dB (no ducking)
    public float maxVolume = -30f;    // -30 dB (heavy ducking)

    void Start()
    {
        fxSlider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(fxSlider.value); // Initialize 

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetSat);
        }

    }

    public void OnSliderValueChanged(float value)
    {
        float distortion = Mathf.Lerp(minDistortion, maxDistortion, value);
        float cutoff = Mathf.Lerp(minCutoff, maxCutoff, value);
        float volume = Mathf.Lerp(minVolume, maxVolume, value);

        mixer.SetFloat(distortionParam, distortion);
        mixer.SetFloat(highpassParam, cutoff);
        mixer.SetFloat(duckVolumeParam, volume);

        Debug.Log("UnityDebug Saturation_" + fxSlider.name + ": " + value * 100 + "%");
    }

    private void ResetSat()
    {
        fxSlider.SetValueWithoutNotify(0f);
        OnSliderValueChanged(fxSlider.value);

        Debug.Log("UnityDebug Saturation_" + fxSlider.name + ": Reseted");
    }
}
