using UnityEngine;

public class AudioFilterManager : MonoBehaviour
{
    public AudioLowPassFilter lowPassFilter;

    public void Apply(string sensitivity)
    {
        switch (sensitivity)
        {
            case "High": SetCutoff(500f); break;
            case "Medium": SetCutoff(3000f); break;
            case "Low": SetCutoff(8000f); break;
        }
    }

    public void SetCutoff(float value)
    {
        lowPassFilter.cutoffFrequency = value;
    }
}
