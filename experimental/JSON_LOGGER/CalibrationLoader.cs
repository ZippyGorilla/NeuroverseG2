using UnityEngine;
using System.IO;

public class CalibrationLoader : MonoBehaviour
{
    public CalibrationLogger logger;

    public void LoadFromFile(string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename);
        if (!File.Exists(path)) {
            Debug.LogWarning("Calibration file not found: " + filename);
            return;
        }

        string json = File.ReadAllText(path);
        CalibrationLog loadedLog = JsonUtility.FromJson<CalibrationLog>(json);

        // Optionally apply last known values to sliders/UI
        foreach (CalibrationEntry entry in loadedLog.entries)
        {
            // You'd match by parameter name and update UI here
            logger.ApplyValueToSlider(entry.parameterName, entry.value);
        }

        Debug.Log("Loaded calibration from: " + filename);
    }
}
