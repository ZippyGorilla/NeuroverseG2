using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSoundEnvs : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider[] sfxSliders;

    public void GetValue()
    {
        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_1");
            musicSlider.SetValueWithoutNotify(0.2f);
            for (int i = 0; i < sfxSliders.Length; i++)
            {
                sfxSliders[i].SetValueWithoutNotify(0.35f);
            }
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_2");
            musicSlider.SetValueWithoutNotify(0.4f);
            for (int i = 0; i < sfxSliders.Length; i++)
            {
                sfxSliders[i].SetValueWithoutNotify(0.55f);
            }
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_3");
            musicSlider.SetValueWithoutNotify(0.6f);
            for (int i = 0; i < sfxSliders.Length; i++)
            {
                sfxSliders[i].SetValueWithoutNotify(0.7f);
            }
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug SoundEnvs: " + "Option_4");
            musicSlider.SetValueWithoutNotify(0.2f);
            for (int i = 0; i < sfxSliders.Length; i++)
            {
                sfxSliders[i].SetValueWithoutNotify(0.2f);
            }
        }
    }
}