using UnityEngine;
using UnityEngine.UI;

public class ToggleSoundSelector : MonoBehaviour
{
    public Toggle[] toggles;              // 4 toggles (part of the same ToggleGroup)
    public GameObject[] soundObjects;     // 4 corresponding GameObjects to activate/deactivate

    void Start()
    {
        if (toggles.Length != soundObjects.Length)
        {
            Debug.LogError("Toggles and soundObjects must match in length!");
            return;
        }

        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        UpdateActiveObject();
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            UpdateActiveObject();
        }
    }

    void UpdateActiveObject()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            soundObjects[i].SetActive(toggles[i].isOn);
        }
    }
}
