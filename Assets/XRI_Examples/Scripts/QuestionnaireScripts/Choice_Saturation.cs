using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSaturation : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] Slider[] Sliders;

    public void GetValue()
    {
        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug Saturation: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug Saturation: " + "Option_1");
            for (int i = 0; i < Sliders.Length; i++)
            {
                Sliders[i].SetValueWithoutNotify(0f);
            }
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug Saturation: " + "Option_2");
            for (int i = 0; i < Sliders.Length; i++)
            {
                Sliders[i].SetValueWithoutNotify(0.2f);
            }
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug Saturation: " + "Option_3");
            for (int i = 0; i < Sliders.Length; i++)
            {
                Sliders[i].SetValueWithoutNotify(0.5f);
            }
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug Saturation: " + "Option_4");
            for (int i = 0; i < Sliders.Length; i++)
            {
                Sliders[i].SetValueWithoutNotify(0f);
            }
        }
    }
}