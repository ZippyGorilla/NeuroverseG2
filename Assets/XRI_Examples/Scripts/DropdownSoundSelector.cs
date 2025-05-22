using TMPro;
using UnityEngine;
using UnityEngine.UI; // or TMPro if using TMP_Dropdown

public class DropdownSoundSelector : MonoBehaviour
{
    public TMP_Dropdown[] dropdowns;
    public GameObject[] eqsAndReverbs;
    public GameObject[] saturationsAndDelays;

    private void Start()
    {
        for (int i = 0; i < dropdowns.Length; i++)
        {
            int index = i; // Capture the loop variable
            dropdowns[i].onValueChanged.AddListener((value) => OnDropdownChanged(index, value));
        }

        for (int i = 0; i < dropdowns.Length; i++)
        {
            OnDropdownChanged(i, dropdowns[i].value);
        }
    }

    void OnDropdownChanged(int index, int value)
    {
        bool isEQ = (value == 0);
        eqsAndReverbs[index].SetActive(isEQ);
        saturationsAndDelays[index].SetActive(!isEQ);
    }
}
