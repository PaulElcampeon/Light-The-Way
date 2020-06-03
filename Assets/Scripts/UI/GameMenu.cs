﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject soundMenu;

    [SerializeField]
    private GameObject controlsMenu;

    [SerializeField]
    private GameObject backButton;

    private void OnEnable()
    {
        backButton.SetActive(true);
    }

    public void ShowSoundMenu()
    {
        SoundManager.instance.PlaySFX(0);

        soundMenu.SetActive(true);
        Debug.Log(soundMenu.activeInHierarchy);

        GameManager.instance.Pause();
    }

    public void ShowControlsMenu()
    {
        SoundManager.instance.PlaySFX(0);

        controlsMenu.SetActive(true);

        GameManager.instance.Pause();
    }

    public void CloseMenu()
    {
        SoundManager.instance.PlaySFX(1);

        if (soundMenu.activeInHierarchy) { soundMenu.SetActive(false); return; }
        if (controlsMenu.activeInHierarchy) { controlsMenu.SetActive(false); return; }


        backButton.SetActive(false);

        GameManager.instance.UnPause();

        gameObject.SetActive(false);
    }

    public void Exit()
    {
        SoundManager.instance.PlaySFX(1);
        SoundManager.instance.StopCurrentBGM();

        GameManager.instance.BackToMainMenu();
    }
}
