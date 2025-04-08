using UnityEngine;

public class VisualFilterManager : MonoBehaviour
{
    public void Apply(string sensitivity)
    {
        switch (sensitivity)
        {
            case "High": SetIntensity(0.3f); break;
            case "Medium": SetIntensity(0.7f); break;
            case "Low": SetIntensity(1.0f); break;
        }
    }

    public void SetIntensity(float value)
    {
        RenderSettings.ambientIntensity = value;
    }
}
