using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacroSelection : MonoBehaviour
{
    public Toggle[] macroSelections;
    public AudioVolumeAndMuteSlider[] audioVolumesScripts;
    public Slider[] volumeSliders;
    public EQCircleController[] eqScripts;
    public RectTransform[] eqHandles;
    public RevCircleController[] reverbScripts;
    public RectTransform[] revHandles;
    public SaturationController[] saturationScripts;
    public Slider[] saturationSliders;
    public EchoController[] delayScripts;
    public Slider[] delaySliders;
    public PitchController[] pitcheScripts;
    public Slider[] pitchSliders;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Toggle macro in macroSelections)
        {
            macro.onValueChanged.AddListener(OnToggleValueChanged);
        }
    }

    void OnToggleValueChanged(bool isOn)
    {
        foreach (Toggle macro in macroSelections)
        {
            if (isOn)
            {
                SetValues(macro.name);
            }
        }
    }

    void SetValues(string name)
    {
        for (int i = 0; i < audioVolumesScripts.Length; i++)
        {
            if (name == "calm")
            {
                volumeSliders[i].SetValueWithoutNotify(0.5f);
                eqHandles[i].anchoredPosition = new Vector2(1f, 1f);
                revHandles[i].anchoredPosition = new Vector2(1f, 1f);
                saturationSliders[i].SetValueWithoutNotify(0.5f);
                delaySliders[i].SetValueWithoutNotify(0.5f);
                pitchSliders[i].SetValueWithoutNotify(0.5f);
                
                audioVolumesScripts[i].ApplyVolume();
                eqScripts[i].SetTargetEQ(1f, 1f);
                reverbScripts[i].SetTargetReverb(1f, 1f);
                saturationScripts[i].OnSliderValueChanged(0.5f);
                delayScripts[i].SetEchoDelay(0.5f);
                pitcheScripts[i].OnSliderChanged(0.5f);
            }
            else if (name == "intense")
            {
                volumeSliders[i].SetValueWithoutNotify(0.5f);
                eqHandles[i].anchoredPosition = new Vector2(1f, 1f);
                revHandles[i].anchoredPosition = new Vector2(1f, 1f);
                saturationSliders[i].SetValueWithoutNotify(0.5f);
                delaySliders[i].SetValueWithoutNotify(0.5f);
                pitchSliders[i].SetValueWithoutNotify(0.5f);
                
                audioVolumesScripts[i].ApplyVolume();
                eqScripts[i].SetTargetEQ(1f, 1f);
                reverbScripts[i].SetTargetReverb(1f, 1f);
                saturationScripts[i].OnSliderValueChanged(0.5f);
                delayScripts[i].SetEchoDelay(0.5f);
                pitcheScripts[i].OnSliderChanged(0.5f);
            }
            else if (name == "fluid")
            {
                volumeSliders[i].SetValueWithoutNotify(0.5f);
                eqHandles[i].anchoredPosition = new Vector2(1f, 1f);
                revHandles[i].anchoredPosition = new Vector2(1f, 1f);
                saturationSliders[i].SetValueWithoutNotify(0.5f);
                delaySliders[i].SetValueWithoutNotify(0.5f);
                pitchSliders[i].SetValueWithoutNotify(0.5f);
                
                audioVolumesScripts[i].ApplyVolume();
                eqScripts[i].SetTargetEQ(1f, 1f);
                reverbScripts[i].SetTargetReverb(1f, 1f);
                saturationScripts[i].OnSliderValueChanged(0.5f);
                delayScripts[i].SetEchoDelay(0.5f);
                pitcheScripts[i].OnSliderChanged(0.5f);
            }
            else if (name == "neutral")
            {
                volumeSliders[i].SetValueWithoutNotify(0.5f);
                eqHandles[i].anchoredPosition = new Vector2(0f, 0f);
                revHandles[i].anchoredPosition = new Vector2(0f, 0f);
                saturationSliders[i].SetValueWithoutNotify(0f);
                delaySliders[i].SetValueWithoutNotify(0f);
                pitchSliders[i].SetValueWithoutNotify(0.36f);
                
                audioVolumesScripts[i].ApplyVolume();
                eqScripts[i].SetTargetEQ(0.33f, 0f);
                reverbScripts[i].SetTargetReverb(0f, 0f);
                saturationScripts[i].OnSliderValueChanged(0f);
                delayScripts[i].SetEchoDelay(0f);
                pitcheScripts[i].OnSliderChanged(0.36f);
            }
            else
            {
                volumeSliders[i].SetValueWithoutNotify(0.5f);
                eqHandles[i].anchoredPosition = new Vector2(0f, 0f);
                revHandles[i].anchoredPosition = new Vector2(0f, 0f);
                saturationSliders[i].SetValueWithoutNotify(0f);
                delaySliders[i].SetValueWithoutNotify(0f);
                pitchSliders[i].SetValueWithoutNotify(0.36f);
                
                audioVolumesScripts[i].ApplyVolume();
                eqScripts[i].SetTargetEQ(0.33f, 0f);
                reverbScripts[i].SetTargetReverb(0f, 0f);
                saturationScripts[i].OnSliderValueChanged(0f);
                delayScripts[i].SetEchoDelay(0f);
                pitcheScripts[i].OnSliderChanged(0.36f);
            }
        }
        
    }
}
