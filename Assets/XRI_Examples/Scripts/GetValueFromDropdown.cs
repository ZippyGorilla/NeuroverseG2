using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetValueFromDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    SoundSettings sSScript;

    void Start()
    {
        sSScript = GameObject.FindGameObjectWithTag("SoundSetSlider").GetComponent<SoundSettings>();
    }



    public void GetDropdownValue()
    {
        int pickedEntryIndex = dropdown.value;

        if (dropdown.value == 1)
        {
            sSScript.QuarterVol();
        }

        //Debug.Log(pickedEntryIndex);

        
    }
}