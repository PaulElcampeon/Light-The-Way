using System.Collections;
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
    private GameObject levelDifficultyMenu;
    [SerializeField]
    private GameObject backButton;

    private void OnEnable()
    {
        backButton.SetActive(true);
    }

    public void ShowSoundMenu()
    {
        soundMenu.SetActive(true);
        GameManager.instance.Pause();
    }

    public void ShowControlsMenu()
    {
        controlsMenu.SetActive(true);
        GameManager.instance.Pause();
    }

    public void ShowLevelDifficultyMenu()
    {
        levelDifficultyMenu.SetActive(true);
        GameManager.instance.Pause();
    }

    public void CloseMenu()
    {
        GameManager.instance.UnPause();

        if (soundMenu.activeInHierarchy) { soundMenu.SetActive(false); return; }
        if (controlsMenu.activeInHierarchy) { controlsMenu.SetActive(false); return; }
        //if (levelDifficultyMenu.activeInHierarchy) { levelDifficultyMenu.SetActive(false); return; }

        backButton.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        GameManager.instance.BackToMainMenu();
    }
}
