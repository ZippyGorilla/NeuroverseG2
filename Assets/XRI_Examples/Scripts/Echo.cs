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

    [Header("Reset Button")]
    public Button resetButton;

    void Start()
    {
        // Optionally set default slider values
        echoDelaySlider.onValueChanged.AddListener(SetEchoDelay);
        SetEchoDelay(echoDelaySlider.value);

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetDelay);
        }
    }

    public void SetEchoDelay(float value)
    {
        float delay = Mathf.Lerp(minDelay, maxDelay, value);
        mixer.SetFloat(echoDelayParam, delay);

        Debug.Log("UnityDebug Delay_" + echoDelaySlider.name + ": " + value * 100 + "%");
    }

    private void ResetDelay()
    {
        echoDelaySlider.SetValueWithoutNotify(0f);
        SetEchoDelay(0f);

        Debug.Log("UnityDebug Delay_" + echoDelaySlider.name + ": Reseted");
    }

}
