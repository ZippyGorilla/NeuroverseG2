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
    public Toggle consentToggle;
    public List<Slider> calibrationSliders;
    public List<string> sliderContexts;
    public List<string> perceptualLabels; // Optional: preset labels based on slider position

    private CalibrationLog log = new CalibrationLog();
    private bool consentGiven = false;

    private void Start() {
        // Attach event listeners to sliders
        for (int i = 0; i < calibrationSliders.Count; i++) {
            int index = i; // avoid closure bug
            calibrationSliders[index].onValueChanged.AddListener(value => OnSliderChanged(index, value));
        }

        if (consentToggle != null)
            consentToggle.onValueChanged.AddListener(OnConsentChanged);
    }

    void OnConsentChanged(bool value) {
        consentGiven = value;
    }

    void OnSliderChanged(int index, float value) {
        if (!consentGiven) return;

        CalibrationEntry entry = new CalibrationEntry {
            timestamp = DateTime.UtcNow.ToString("s"),
            context = sliderContexts[index],
            parameterName = calibrationSliders[index].name,
            value = value,
            perceptualLabel = GetPerceptualLabel(value)
        };

        log.entries.Add(entry);
        Debug.Log($"[Calibration Log] {entry.parameterName} = {entry.value} ({entry.perceptualLabel})");
    }

    string GetPerceptualLabel(float value) {
        if (perceptualLabels == null || perceptualLabels.Count == 0)
            return "Unlabeled";

        int index = Mathf.FloorToInt(value * (perceptualLabels.Count - 1));
        return perceptualLabels[Mathf.Clamp(index, 0, perceptualLabels.Count - 1)];
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
        Debug.Log($"Calibration log saved to: {path}");
    }
}
