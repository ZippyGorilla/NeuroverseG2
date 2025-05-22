using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSoundTexture : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] RectTransform[] eqHandles;

    [SerializeField] EQCircleController[] scripts;

    private Vector2 pos;

    public void GetValue()
    {
        int pickedEntryIndex = dropdown.value;

        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug SoundTexture: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug SoundTexture: " + "Option_1");
            for (int i = 0; i < eqHandles.Length; i++)
            {
                pos.x = 35f;
                pos.y = -35f;
                eqHandles[i].anchoredPosition = pos;

                scripts[i].SetTargetEQ(-1f, 1f);
            }
        }

        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug SoundTexture: " + "Option_2");
            for (int i = 0; i < eqHandles.Length; i++)
            {
                pos.x = 0f;
                pos.y = 0f;
                eqHandles[i].anchoredPosition = pos;
                
                scripts[i].SetTargetEQ(-0.36f, -0.5f);
            }
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug SoundTexture: " + "Option_3");
            for (int i = 0; i < eqHandles.Length; i++)
            {
                pos.x = 35f;
                pos.y = 35f;
                eqHandles[i].anchoredPosition = pos;
                
                scripts[i].SetTargetEQ(1f, 1f);
            }
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug SoundTexture: " + "Option_4");
            for (int i = 0; i < eqHandles.Length; i++)
            {
                pos.x = 0f;
                pos.y = 0f;
                eqHandles[i].anchoredPosition = pos;
                
                scripts[i].SetTargetEQ(-0.36f, 0f);
            }
        }
    }
}