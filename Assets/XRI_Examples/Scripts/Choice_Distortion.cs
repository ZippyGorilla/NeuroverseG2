using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Choice_Distortion : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown dropdown;
    //dropdown.value

    [SerializeField] FXSliderControl saturation; //Should serialize the field to show it exactly what slider to use :)

    void Start()
    {
        //Below is not needed because it's not finding the object... not even ME lab knows why.
        //saturation = GameObject.FindGameObjectWithTag("saturation").GetComponent<FXSliderControl>();
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
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_2");
            saturation.RefreshSlider(0.1f);
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_3");
            saturation.RefreshSlider(0.7f);
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_4");
        }
    }
}