using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EQFrequencySlider : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;
    public string frequencyParam = "Band1Freq"; // Exposed parameter for frequency

    [Header("UI")]
    public Slider slider;
    public float minFreq = 20f;     // Human hearing range min
    public float maxFreq = 20000f;  // Human hearing range max

    void Start()
    {
        // Slider range should go 0–1 for smoother log scaling
        slider.minValue = 0f;
        slider.maxValue = 1f;

        float currentFreq;
        audioMixer.GetFloat(frequencyParam, out currentFreq);
        slider.value = Mathf.InverseLerp(Mathf.Log10(minFreq), Mathf.Log10(maxFreq), Mathf.Log10(currentFreq));

        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float sliderValue)
    {
        // Use logarithmic scale for frequency (for natural audio feel)
        float freq = Mathf.Pow(10, Mathf.Lerp(Mathf.Log10(minFreq), Mathf.Log10(maxFreq), sliderValue));
        audioMixer.SetFloat(frequencyParam, freq);
    }
}
