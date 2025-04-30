using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class reactLoudSoundChoice : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    public void GetDropdownValue() 
    {
        int pickedEntryIndex = dropdown.value;

        Debug.Log(pickedEntryIndex);
    }
}
