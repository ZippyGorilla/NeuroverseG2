/*
using UnityEngine;
using UnityEngine.UI;

public class HalfVolume : MonoBehaviour
{  
    //[SerializeField] private Button button;
    //[SerializeField] Slider soundSlider;
    //[SerializeField] AudioMixer masterMixer;
    private void Start() { 
        // 'Subscribe' to an HalfVol :)
        button.onClick.AddListener(HalfVol); 
    }

    private void OnDestroy() {
        button.onClick.RemoveListener(HalfVol);
    }

    public void SetVolume(float _value) {
        if(_value < 1) {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);   
    }

    public void HalfVol() {
        //Set the Master volume slider to its mid-point.
        SetVolume(50);
    }

    public void RefreshSlider(float _value) {
        soundSlider.value = _value;
    }
}
*/