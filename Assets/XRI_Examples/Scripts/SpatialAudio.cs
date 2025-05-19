using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpatialAudio : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;



    public void GetValue()
    {
        int pickedEntryIndex = dropdown.value;

        Debug.Log(pickedEntryIndex);
    }
}