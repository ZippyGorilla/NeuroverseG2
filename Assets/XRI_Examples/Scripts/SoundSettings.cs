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
    private float timeToSettle = 0.15f; // desired delay in seconds
    private float velocity = 0f; //SmoothDamp


    private void Start() {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume, 0.0")); 
        SetVolume(0);
    }

    public void SetVolume(float _value) {
        if(_value < 1) {
            _value = .001f;
        }

        RefreshSlider(_value);
        //masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);   
    }

    public void SetVolumeFromSlider() {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value) {
        soundSlider.value = _value;
    }

    void Update () { 
        // Always read the latest slider position as target (lastValue)
        lastValue = soundSlider.value;
        
        // SmoothDamp gives eased interpolation toward lastValue
        smoothedValue = Mathf.SmoothDamp(smoothedValue, lastValue, ref velocity, timeToSettle);

        Debug.Log("UpdateSmooth: " + smoothedValue);
         // Apply to system
        PlayerPrefs.SetFloat("SavedMasterVolume", smoothedValue);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(smoothedValue / 100) * 20f);
    }

    void aUpdate() {
        // Always read the latest slider position as target (lastValue)
        lastValue = soundSlider.value;

        //smoothing toward target
        float alpha = 1f - Mathf.Exp(-Time.deltaTime / timeToSettle);
        smoothedValue += alpha * (lastValue - smoothedValue);

        // Snap when close to prevent infinite drift
        if (Mathf.Abs(lastValue - smoothedValue) < 0.001f) smoothedValue = lastValue;

        Debug.Log("UpdateSmooth: " + smoothedValue);

        // Apply to system
        PlayerPrefs.SetFloat("SavedMasterVolume", smoothedValue);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(smoothedValue / 100) * 20f);
    }



    public void QuarterVol() { //Set the Master volume slider to its mid-point.
        SetVolume(25);
    }

}