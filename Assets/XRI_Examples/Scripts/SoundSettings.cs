using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float smoothedValue = 0f;
    private float lastValue = 0f;
    private float timeToSettle = 0.15f; // desired delay in seconds
    private float velocity = 0f; //SmoothDamp

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume, 8.0")); 
        SetVolume(8); // Start with a low value :)
    }

    public void SetVolume(float _value) {
        if(_value < 1) {
            _value = .001f;
        }

        RefreshSlider(_value);
        //masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);   
    }

    public void SetVolumeFromSlider() {
        Debug.Log("UnityDebug Master_Vol_(Slider): " + soundSlider.value);
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

        //Debug.Log("UnityDebug Master_Volume: " + smoothedValue);
        // Apply to system
        PlayerPrefs.SetFloat("SavedMasterVolume", smoothedValue);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(smoothedValue / 100) * 20f);
    }

    public void QuarterVol() { //Set the Master volume slider to its quarter-point.
        SetVolume(25);
    }

}