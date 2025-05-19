using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

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

    void Start()
    {
        // Optionally set default slider values
        pitchSlider.onValueChanged.AddListener(SetPitch);
        SetPitch(pitchSlider.value);
    }

    public void SetPitch(float value)
    {
        float pitch = Mathf.Lerp(minPitch, maxPitch, value);
        mixer.SetFloat(pitchParam, pitch);
    }
}
