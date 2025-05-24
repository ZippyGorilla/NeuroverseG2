using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceReverb : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] RectTransform[] revHandles;

    [SerializeField] RevCircleController[] scripts;

    private Vector2 pos;

    public void GetValue()
    {
        int pickedEntryIndex = dropdown.value;

        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug Reverb: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug Reverb: " + "Option_1");
            for (int i = 0; i < revHandles.Length; i++)
            {
                pos.x = 0f;
                pos.y = -50f;
                revHandles[i].anchoredPosition = pos;

                scripts[i].SetTargetReverb(0f, -1f);
            }
        }

        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug Reverb: " + "Option_2");
            for (int i = 0; i < revHandles.Length; i++)
            {
                pos.x = 0f;
                pos.y = 0f;
                revHandles[i].anchoredPosition = pos;
                
                scripts[i].SetTargetReverb(0f, 0f);
            }
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug Reverb: " + "Option_3");
            for (int i = 0; i < revHandles.Length; i++)
            {
                pos.x = 35f;
                pos.y = 35f;
                revHandles[i].anchoredPosition = pos;
                
                scripts[i].SetTargetReverb(1f, 1f);
            }
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug Reverb: " + "Option_4");
            for (int i = 0; i < revHandles.Length; i++)
            {
                pos.x = 0f;
                pos.y = 0f;
                revHandles[i].anchoredPosition = pos;
                
                scripts[i].SetTargetReverb(0f, 0f);
            }
        }
    }
}