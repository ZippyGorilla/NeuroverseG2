using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using TMPro;

public class CalibrationLoader : MonoBehaviour
{
    [Header("🧠 Logger Reference")]
    public CalibrationLogger logger;

    [Header("📁 UI Elements")]
    public TMP_Dropdown fileDropdown;
    public Button loadButton;

    private List<string> fileNames = new List<string>();

    private void Start()
    {
        if (loadButton != null)
            loadButton.onClick.AddListener(OnLoadButtonPressed);

        PopulateDropdown();
    }

    void PopulateDropdown()
    {
        string dir = Application.persistentDataPath;
        DirectoryInfo di = new DirectoryInfo(dir);
        FileInfo[] files = di.GetFiles("calibration_log_*.json");

        fileDropdown.ClearOptions();
        fileNames.Clear();

        foreach (FileInfo f in files)
        {
            fileNames.Add(f.Name);
        }

        if (fileNames.Count > 0)
        {
            fileDropdown.AddOptions(fileNames);
        }
        else
        {
            fileDropdown.AddOptions(new List<string> { "No logs found" });
            loadButton.interactable = false;
        }
    }

    void OnLoadButtonPressed()
    {
        if (fileDropdown.options.Count == 0 || fileNames.Count == 0)
            return;

        string selectedFile = fileNames[fileDropdown.value];
        logger.LoadCalibrationLog(selectedFile);
    }
}
