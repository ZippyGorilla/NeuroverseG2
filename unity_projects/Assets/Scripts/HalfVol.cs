/*
using UnityEngine;
//using UnityEngine.Audio;
//using UnityEngine.UI;

public class HalfVol : MonoBehaviour
{
    //[SerializeField] private Button button;
    //[SerializeField] Slider soundSlider;
    //[SerializeField] AudioMixer masterMixer;
    private void Start() { 
        // 'Subscribe' to an HalfVolume :)
        button.onClick.AddListener(HalfVolume); 
    }

    private void OnDestroy() {
        button.onClick.RemoveListener(HalfVolume);
    }

    public void SetVolume(float _value) {
        if(_value < 1) {
            _value = .001f;
        }

        //RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);   
    }

    public void HalfVolume() {
        //Set the Master volume slider to its mid-point.
        SetVolume(50);
    }

    //public void RefreshSlider(float _value) {
        //soundSlider.value = _value;
    //}
}
*/