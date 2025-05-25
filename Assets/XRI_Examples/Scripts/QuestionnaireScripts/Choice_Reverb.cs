using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceReverb : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown; // The Question

    [SerializeField] RectTransform[] revHandles; // The Objects

    [SerializeField] RevCircleController[] scripts; // The Scripts; Their value creating propriety has to be public

    private Vector2 pos;

    public void GetValue() // As soon as the dropdown changes, its value is registered
    {
        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug Reverb: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug Reverb: " + "Option_1");
            for (int i = 0; i < revHandles.Length; i++)
            {
                // Setting the position of the handle
                pos.x = 0f;
                pos.y = -50f;
                revHandles[i].anchoredPosition = pos;
                // In sliders it is just a SetValueWithoutNotify property

                // Set the reverbs based on that position
                // Easier writing the positions in numbers than using the defined number
                // from above because it is not in coordinates but in pixels
                scripts[i].SetTargetReverb(0f, -1f);
            }
        }

        // Same for every other option
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