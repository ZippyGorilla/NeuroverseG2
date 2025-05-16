using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VisualSettings : MonoBehaviour
{
    [SerializeField] Slider visSlider;
    DarknessOverlayGradient darkOverlayG;
    private float smoothedValue = 0f;
    private float lastValue = 0f;
    private float timeToSettle = 0.15f; // desired delay in seconds
    private float velocity = 0f; //SmoothDamp

    private void Start() {
        darkOverlayG = GameObject.FindGameObjectWithTag("ND_Sound").GetComponent<DarknessOverlayGradient>();
        SetVal(75); //Out of 100.
    }

    void Update () { 
        // Always read the latest slider position as target (lastValue)
        lastValue = visSlider.value;
        
        // SmoothDamp gives eased interpolation toward lastValue
        smoothedValue = Mathf.SmoothDamp(smoothedValue, lastValue, ref velocity, timeToSettle);

        //Debug.Log("brightSmooth: " + smoothedValue);

         // Apply to system
        darkOverlayG.SetZoneDarkness(smoothedValue/100f);
    }

    public void SetVal(float _value) { 

        RefreshSlider(_value);  
        //darkOverlayG.SetZoneDarkness(_value/100f);
    }

    public void SetValFromSlider() {
        SetVal(visSlider.value);
    }

    public void RefreshSlider(float _value) {
        visSlider.value = _value;
    }

    public void QuarterSlider() {
        SetVal(25);
    }

}