using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Choice_SoundEnvs : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    SoundSettings sSScript;
    SoundSettings sfxVol;

    void Start()
    {
        sSScript = GameObject.FindGameObjectWithTag("musicVol").GetComponent<SoundSettings>();
        sfxVol = GameObject.FindGameObjectWithTag("sfxVol").GetComponent<SoundSettings>();
    }

    public void GetValue()
    {
        int pickedEntryIndex = dropdown.value;

        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_1");
            sSScript.musHighlySensitiveVol();
            sfxVol.sfxHighlySensitiveVol();
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_2");
            sSScript.musModerateVol();
            sfxVol.sfxModerateVol();
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_3");
            sSScript.musUnderResponsiveVol();
            sfxVol.sfxUnderResponsiveVol();
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_4");
        }
    }

}