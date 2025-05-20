using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    SoundSettings sSScript;

    void Start()
    {
        sSScript = GameObject.FindGameObjectWithTag("SoundSetSlider").GetComponent<SoundSettings>();
    }



    public void GetValue()
    {
        int pickedEntryIndex = dropdown.value;

        if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug Ambient_Sound: " + "Option_1");
             sSScript.QuarterVol();
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug Ambient_Sound: " + "Option_2");
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug Ambient_Sound: " + "Option_3");
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug Ambient_Sound: " + "Option_4");
        }
        
    }
}