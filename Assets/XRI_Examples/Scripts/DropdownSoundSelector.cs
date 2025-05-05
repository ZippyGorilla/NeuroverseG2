using TMPro;
using UnityEngine;
using UnityEngine.UI; // or TMPro if using TMP_Dropdown

public class DropdownSoundSelector : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameObject eqPanel;
    public GameObject reverbPanel;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        OnDropdownValueChanged(dropdown.value); // Initialize
    }

    private void OnDropdownValueChanged(int index)
    {
        switch (index)
        {
            case 0: // Option A - EQ
                eqPanel.SetActive(true);
                reverbPanel.SetActive(false);
                break;
            case 1: // Option B - Reverb
                eqPanel.SetActive(false);
                reverbPanel.SetActive(true);
                break;
        }
    }
}
