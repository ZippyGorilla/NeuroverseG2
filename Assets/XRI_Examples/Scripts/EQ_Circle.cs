using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EQCircleController : MonoBehaviour
{
    // The necessary objects that need to be assigned on the editor
    public RectTransform circleArea;
    public RectTransform handle;
    public Button resetButton;
    public AudioMixer mixer;

    // The exposed mixer parameters with the specific names
    // (public so they can be defined in the editor)
    public string gainParameter = "FreqG";
    public string frequencyParameter = "CFreq";

    //Ranges for Frequency Gain and Center Frequency
    public float maxGain = 3f;
    public float minGain = 0.05f;
    public float minFreq = 20f;
    public float maxFreq = 8000f;

    private Vector2 center;

    // Parameters for smoothing
    private float targetGain = 1f;
    private float targetFreq = 8000f;
    private float currentGain;
    private float currentFreq;
    private float gainVelocity;
    private float freqVelocity;
    public float smoothTime = 0.1f; // Time to smooth toward target values

    void Start() //Initialize, making the class aware of reset button
    {
        center = circleArea.rect.center;

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetEQSettings);
        }

        currentGain = targetGain;
        currentFreq = targetFreq;
    }

    // This function is called by the EQHandleDragRelay, which provides the
    // position information of the handle in the screen
    public void ProcessDrag(Vector2 screenPosition, Camera eventCamera)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleArea, screenPosition, eventCamera, out localPoint);

        // Since there is only a rectangle in object manipulation, a circle has to be created
        Vector2 offset = localPoint - center; // checks the distance of the immediate point of the handle compared to the center
        float radius = circleArea.rect.width * 0.5f; // defining the radius

        if (offset.magnitude > radius)
            offset = offset.normalized * radius; // Sets the offset to a normalized point within the circle

        handle.anchoredPosition = offset; // Sets the handle based on that offset

        float normX = offset.x / radius; // Turns x and y to numbers from -1 to 1
        float normY = offset.y / radius;

        SetTargetEQ(normX, normY);
    }

    // Sets the targetGain and targetFreq that will then be smoothed
    // in the update function
    public void SetTargetEQ(float x, float y)
    {
        // Since x and y are from -1 to 1, they have to be normalized from 0 to 1 by
        // doing (x+1)/2 [when x=-1, val=(-1+1)/2=0, vice versa]
        targetGain = Mathf.Lerp(minGain, maxGain, (x + 1) / 2f);

        // Logarithmic scale for shorter turns; minFreq = 0.05f as log(0) does not exist
        float logMin = Mathf.Log10(minFreq);
        float logMax = Mathf.Log10(maxFreq);
        float logFreq = Mathf.Lerp(logMin, logMax, (y + 1f) / 2f);
        targetFreq = Mathf.Pow(10f, logFreq);

        // Logs the result for data analysis
        Debug.Log("UnityDebug EQ_" + handle.name + ": " + $"Gain:{currentGain}dB,Frequency:{currentFreq}Hz,x:{x},y:{y}");
    }
    
    void Update() // Happens every frame; where smoothing must occur
    {
        currentGain = Mathf.SmoothDamp(currentGain, targetGain, ref gainVelocity, smoothTime);
        currentFreq = Mathf.SmoothDamp(currentFreq, targetFreq, ref freqVelocity, smoothTime);

        mixer.SetFloat(gainParameter, currentGain); // Function that sets the desired values
        mixer.SetFloat(frequencyParameter, currentFreq);
    }

    public void ResetEQSettings() // Programs the button to reset to its original position
    {
        handle.anchoredPosition = Vector2.zero;
        SetTargetEQ(-0.36f, 0f); // Reset to neutral values

        Debug.Log("UnityDebug EQ_" + handle.name + ": Reseted");
    }
}
