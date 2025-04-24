using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume, 0.0")); 
        SetVolume(10);
    }

    public void SetVolume(float _value) {
        if(_value < 1) {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);   
    }

    public void SetVolumeFromSlider() {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value) {
        soundSlider.value = _value;
    }

    public void HalfVol() { //Set the Master volume slider to its mid-point.
        SetVolume(50);
    }

}