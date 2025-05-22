using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EchoController : MonoBehaviour
{
    public AudioMixer mixer;

    [Header("Sliders")]
    public Slider echoDelaySlider;

    [Header("Mixer Parameters")]
    public string echoDelayParam = "echoDelay";

    [Header("Ranges")]
    public float minDelay = 10f;
    public float maxDelay = 5000f;

    void Start()
    {
        // Optionally set default slider values
        echoDelaySlider.onValueChanged.AddListener(SetEchoDelay);
        SetEchoDelay(echoDelaySlider.value);
    }

    public void SetEchoDelay(float value)
    {
        float delay = Mathf.Lerp(minDelay, maxDelay, value);
        mixer.SetFloat(echoDelayParam, delay);
    }

    public void SetDelayFast(float value)
    {
        float delay = Mathf.Lerp(minDelay, maxDelay, value);
        mixer.SetFloat(echoDelayParam, delay);
    }

}
