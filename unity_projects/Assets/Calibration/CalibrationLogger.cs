using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CalibrationEntry {
    public string timestamp;
    public string context;
    public string parameterName;
    public float value;
    public string perceptualLabel;
}

[System.Serializable]
public class CalibrationLog {
    public List<CalibrationEntry> entries = new List<CalibrationEntry>();
}

public class CalibrationLogger : MonoBehaviour {
    [Header("🔐 GDPR Consent")]
    public Toggle consentToggle;

    [Header("🎛️ UI Elements")]
    public List<Slider> calibrationSliders;
    public List<string> sliderContexts;

    private CalibrationLog log = new CalibrationLog();
    private bool consentGiven = false;

    private void Start() {
        if (consentToggle != null)
            consentToggle.onValueChanged.AddListener(OnConsentChanged);

        for (int i = 0; i < calibrationSliders.Count; i++) {
            int index = i;
            calibrationSliders[index].onValueChanged.AddListener(value => OnSliderChanged(index, value));
        }
    }

    public void OnConsentChanged(bool value) {
        consentGiven = value;
    }

    private void OnSliderChanged(int index, float value) {
        if (!consentGiven) return;

        string parameterName = calibrationSliders[index].name;
        string context = sliderContexts[index];
        string perceptualLabel = GetPerceptualLabel(value, context);
        string fullContext = $"User is adjusting {context.ToLower()} sensitivity";

        LogSliderChange(parameterName, value, fullContext, perceptualLabel);
    }

    public void LogSliderChange(string parameterName, float value, string context, string perceptualLabel) {
        CalibrationEntry entry = new CalibrationEntry {
            timestamp = DateTime.UtcNow.ToString("o"),
            parameterName = parameterName,
            value = value,
            context = context,
            perceptualLabel = perceptualLabel
        };

        log.entries.Add(entry);
        Debug.Log($"📊 {context}: {parameterName} = {value} ({perceptualLabel}) @ {entry.timestamp}");
    }

    private string GetPerceptualLabel(float value, string context) {
        switch (context.ToLower()) {
            case "visual":
                return value < 0.4f ? "Dim" : value < 0.8f ? "Balanced" : "Bright";

            case "audio":
                return value < 1000f ? "Muffled" : value < 6000f ? "Clear" : "Crisp";

            case "haptic":
                return value < 0.3f ? "Soft" : value < 0.6f ? "Noticeable" : "Strong";

            case "motion":
                return value < 0.6f ? "Slow" : value < 1.2f ? "Natural" : "Fast";

            default:
                return "Unknown";
        }
    }

    public void SaveCalibrationLog() {
        if (!consentGiven || log.entries.Count == 0) {
            Debug.LogWarning("Consent not given or log is empty — not saving.");
            return;
        }

        string filename = $"calibration_log_{DateTime.Now:yyyy-MM-dd_HH-mm}.json";
        string path = Path.Combine(Application.persistentDataPath, filename);
        string json = JsonUtility.ToJson(log, true);
        File.WriteAllText(path, json);
        Debug.Log($"✅ Calibration log saved: {path}");
    }

    public void ApplyValueToSlider(string paramName, float value) {
        foreach (Slider s in calibrationSliders) {
            if (s.name == paramName) {
                s.value = value;
                Debug.Log($"🔄 Restored slider {paramName} to value {value}");
                break;
            }
        }
    }

    public void LoadCalibrationLog(string filename) {
        string path = Path.Combine(Application.persistentDataPath, filename);
        if (!File.Exists(path)) {
            Debug.LogWarning($"📁 Calibration log not found: {filename}");
            return;
        }

        string json = File.ReadAllText(path);
        CalibrationLog loadedLog = JsonUtility.FromJson<CalibrationLog>(json);

        foreach (CalibrationEntry entry in loadedLog.entries) {
            ApplyValueToSlider(entry.parameterName, entry.value);
        }

        Debug.Log($"✅ Loaded calibration session: {filename}");
    }
}



