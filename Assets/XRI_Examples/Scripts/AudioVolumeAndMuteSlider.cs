using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeAndMuteSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;
    public AudioMixer mixer;
    public string volumeParameter = "MasterVolume";

    private float timeToSettle = 0.15f; // Smoothing time in seconds

    private float smoothedValue;
    private float velocity = 0f; // Required by SmoothDamp

    private const float minDecibels = -80f;

    void Start()
    {
        float initialValue = PlayerPrefs.GetFloat("SavedMasterVolume", 1f);
        volumeSlider.value = initialValue;
        smoothedValue = initialValue;

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        muteToggle.onValueChanged.AddListener(OnMuteChanged);

        ApplyVolume(); // Apply at start
    }

    void Update()
    {
        if (!muteToggle.isOn)
        {
            float targetValue = volumeSlider.value;
            smoothedValue = Mathf.SmoothDamp(smoothedValue, targetValue, ref velocity, timeToSettle);
            ApplyVolume();
        }
    }

    public void OnVolumeChanged(float val)
    {
        if (!muteToggle.isOn)
        {
            PlayerPrefs.SetFloat("SavedMasterVolume", val);
            Debug.Log("UnityDebug Volume_" + volumeSlider.name + ": " + val * 100 + "%");
        }
    }

    void OnMuteChanged(bool isMuted)
    {
        ApplyVolume();
        if (isMuted)
        {
            Debug.Log("UnityDebug Mute_" + muteToggle.name + ": Muted");
        }
        else
        {
            Debug.Log("UnityDebug Mute_" + muteToggle.name + ": Unmuted");
        }
    }

    public void ApplyVolume()
    {
        float value = muteToggle.isOn ? 0.0001f : Mathf.Clamp(smoothedValue, 0.0001f, 1f); // Avoid log(0)
        float dB = muteToggle.isOn ? minDecibels : Mathf.Log10(value) * 20f;

        mixer.SetFloat(volumeParameter, dB);
    }
}
