using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Choice_SoundTexture : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] EQCircleController paramEqScript;
    //public EQCircleController test;

    void Start()
    {
        //paramEqScript = GameObject.FindGameObjectWithTag("eqHandle").GetComponent<EQCircleController>();
    }

    public void GetValue()
    {
        int pickedEntryIndex = dropdown.value;

        if (dropdown.value == 0)
        {
            Debug.Log("UnityDebug Sound_Texture: " + "No_option_chosen");
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("UnityDebug Sound_Texture: " + "Option_1");
            //test.ApplyEQ(3, 10);
            //paramEqScript.ApplyEQ(3, 10);
            paramEqScript.test();
        }
        else if (dropdown.value == 2)
        {
            Debug.Log("UnityDebug Sound_Texture: " + "Option_2");
        }
        else if (dropdown.value == 3)
        {
            Debug.Log("UnityDebug Sound_Texture: " + "Option_3");
            //paramEqScript.ApplyEQ(3, 8000);
            paramEqScript.test();
        }
        else if (dropdown.value == 4)
        {
            Debug.Log("UnityDebug Sound_Texture: " + "Option_4");
        }
    }
}