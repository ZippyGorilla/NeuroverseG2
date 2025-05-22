using TMPro;
using UnityEngine;
using UnityEngine.UI; // or TMPro if using TMP_Dropdown

public class DropdownSoundSelector : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameObject eqAndReverb;
    public GameObject saturationAndDelay;

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
                eqAndReverb.SetActive(true);
                saturationAndDelay.SetActive(false);
                break;
            case 1: // Option B - Reverb
                eqAndReverb.SetActive(false);
                saturationAndDelay.SetActive(true);
                break;
        }
    }
}
