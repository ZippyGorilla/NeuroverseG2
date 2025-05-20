using UnityEngine;
using UnityEngine.UI; // or TMPro if using TMP_Dropdown

public class ToggleMenuSelector : MonoBehaviour
{
    public Toggle toggle;
    public GameObject soundSettings;
    public GameObject sxfSettings;

    private void Start()
    {
        toggle.onValueChanged.AddListener(OntoggleValueChanged);
        OntoggleValueChanged(toggle); // Initialize
    }

    private void OntoggleValueChanged(int index)
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
