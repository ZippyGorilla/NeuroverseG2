using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //vvv Euler Smoothing Algorithms variables vvv
    public float minAlpha = 0.05f;
    public float maxAlpha = 0.3f;
    public float maxSpeed = 2.0f;

    private float smoothedValue = 0f;
    private float lastValue = 0f;

    private void Start() {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume, 0.0")); 
        SetVolume(0);
    }

    public void SetVolume(float _value) {
        if(_value < 1) {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(SmoothSlide(_value) / 100) * 20f);   
    }

    public void SetVolumeFromSlider() {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value) {
        soundSlider.value = _value;
    }

    private float SmoothSlide(float raw) {
        float speed = Mathf.Abs(raw - lastValue) / Time.deltaTime;
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.Clamp01(speed / maxSpeed));

        smoothedValue += alpha * (raw - smoothedValue);
        lastValue = raw;

        // Apply to audio engine or UI
        return smoothedValue;
    }

    public void QuarterVol() { //Set the Master volume slider to its mid-point.
        SetVolume(25);
    }

}