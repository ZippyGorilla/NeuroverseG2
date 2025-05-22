using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMuteAmbient : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] Toggle[] Toggles;

    public void GetValue()
    {
        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug MuteAudio: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug MuteAudio: " + "Option_1");
            for (int i = 0; i < Toggles.Length; i++)
            {
                Toggles[i].SetIsOnWithoutNotify(true);
            }
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug MuteAudio: " + "Option_2");
            for (int i = 0; i < Toggles.Length; i++)
            {
                Toggles[i].SetIsOnWithoutNotify(false);
            }
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug MuteAudio: " + "Option_3");
            for (int i = 0; i < Toggles.Length; i++)
            {
                Toggles[i].SetIsOnWithoutNotify(false);
            }
        }
    }
}