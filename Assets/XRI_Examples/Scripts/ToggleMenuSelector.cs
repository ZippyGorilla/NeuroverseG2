using UnityEngine;
using UnityEngine.UI; // or TMPro if using TMP_Dropdown

public class ToggleMenuSelector : MonoBehaviour
{
    public Toggle toggle;
    public GameObject soundSettings;
    public GameObject soundSettingsLabel;
    public GameObject sxfSettings;
    public GameObject sxfSettingsLabel;

    private void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
        OnToggleChanged(toggle.isOn); // Initialize
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            soundSettings.SetActive(false);
            soundSettingsLabel.SetActive(false);
            sxfSettings.SetActive(true);
            sxfSettingsLabel.SetActive(true);
        }
        else
        {
            soundSettings.SetActive(true);
            soundSettingsLabel.SetActive(true);
            sxfSettings.SetActive(false);
            sxfSettingsLabel.SetActive(false);
        }
    }
}
