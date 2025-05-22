using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenScene : MonoBehaviour
{
    public InputActionReference soundMenu;
    public AudioSource music;
    private bool firstopen = false;
    private bool hasActiveSound = false;

    void Start()
    {
        AudioListener.volume = 0;
    }

    void OnEnable()
    {
        if (!firstopen)
        {
            soundMenu.action.performed += TurnOnSound;
            soundMenu.action.Enable();
            firstopen = true;
        }
    }

    private void OnDisable()
    {
        if (soundMenu != null)
        {
            soundMenu.action.performed -= TurnOnSound;
            soundMenu.action.Disable();
        }
    }

    private void TurnOnSound(InputAction.CallbackContext context)
    {
        if (hasActiveSound) return;

        hasActiveSound = true;

        StartCoroutine(FadeInSound());
    }

    private IEnumerator FadeInSound()
    {
        music.Play();

        float duration = 5f; // seconds per step
        int steps = 4;
        float stepAmount = 1f / steps;

        for (int i = 0; i < steps; i++)
        {
            AudioListener.volume = Mathf.Clamp01(AudioListener.volume + stepAmount);
            yield return new WaitForSecondsRealtime(duration);
        }

    }

}
