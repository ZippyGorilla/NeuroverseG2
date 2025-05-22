using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FXSliderControl : MonoBehaviour
{
    public Slider fxSlider;
    public AudioMixer mixer;

    [Header("Mixer Parameters")]
    public string distortionParam = "DistortionAmount";
    public string highpassParam = "HighpassCutoff";
    public string duckVolumeParam = "DuckVolume";

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
        //Debug.Log("Choice_Distortion" + GetComponent<this>());
    }

    public void OnSliderValueChanged(float value)
    {
        float distortion = Mathf.Lerp(minDistortion, maxDistortion, value);
        float cutoff = Mathf.Lerp(minCutoff, maxCutoff, value);
        float volume = Mathf.Lerp(minVolume, maxVolume, value);

        mixer.SetFloat(distortionParam, distortion);
        mixer.SetFloat(highpassParam, cutoff);
        mixer.SetFloat(duckVolumeParam, volume);
    }

    public void RefreshSlider(float _value)
    {
        fxSlider.value = _value;
        OnSliderValueChanged(fxSlider.value);
    }
}
