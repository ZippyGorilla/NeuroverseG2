using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class UserProfileManager : MonoBehaviour
{
    public static UserProfileManager Instance;
    public UserProfile CurrentProfile;
    private string profilePath => Application.persistentDataPath + "/user_profile.json";

    void Awake()
    {
        if (Instance == null) Instance = this;
        LoadProfile();
    }

    public void LoadProfile()
    {
        if (File.Exists(profilePath))
        {
            string json = File.ReadAllText(profilePath);
            CurrentProfile = JsonUtility.FromJson<UserProfile>(json);
        }
        else
        {
            CurrentProfile = new UserProfile();
            SaveProfile();
        }
    }

    public void SaveProfile()
    {
        string json = JsonUtility.ToJson(CurrentProfile, true);
        File.WriteAllText(profilePath, json);
    }
}

[System.Serializable]
public class UserProfile
{
    public string VisualSensitivity = "Medium";
    public string AudioSensitivity = "Medium";
    public string HapticSensitivity = "Medium";
    public string MotionSensitivity = "Medium";

    public bool OptOutVisual = false;
    public bool OptOutAudio = false;
    public bool OptOutHaptics = false;
    public bool OptOutMotion = false;

    public float VisualIntensity = 0.7f;
    public float AudioCutoff = 3000f;
    public float HapticStrength = 0.4f;
    public float MotionSmoothness = 1.0f;

    public string TactileTexturePreference = "Smooth";
}