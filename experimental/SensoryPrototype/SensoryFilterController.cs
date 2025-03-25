cat <<EOF > SensoryFilterController.cs
using UnityEngine;

public class SensoryFilterController : MonoBehaviour
{
    public VisualFilterManager visualManager;
    public AudioFilterManager audioManager;
    public HapticManager hapticManager;
    public MotionSmoothingManager motionManager;

    void Start()
    {
        var profile = UserProfileManager.Instance.CurrentProfile;

        if (!profile.OptOutVisual) visualManager.Apply(profile.VisualSensitivity);
        if (!profile.OptOutAudio) audioManager.Apply(profile.AudioSensitivity);
        if (!profile.OptOutHaptics) hapticManager.Configure(profile.HapticSensitivity);
        if (!profile.OptOutMotion) motionManager.Apply(profile.MotionSensitivity);
    }

    public void ApplyFromProfile()
    {
        Start();
    }
}
EOF

