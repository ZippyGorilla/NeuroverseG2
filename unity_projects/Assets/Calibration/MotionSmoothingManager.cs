using UnityEngine;

public class MotionSmoothingManager : MonoBehaviour
{
    public Animator cameraAnimator;

    public void Apply(string sensitivity)
    {
        switch (sensitivity)
        {
            case "High": SetSmoothness(1.5f); break;
            case "Medium": SetSmoothness(1.0f); break;
            case "Low": SetSmoothness(0.5f); break;
        }
    }

    public void SetSmoothness(float value)
    {
        cameraAnimator.SetFloat("TransitionSpeed", value);
    }
}
