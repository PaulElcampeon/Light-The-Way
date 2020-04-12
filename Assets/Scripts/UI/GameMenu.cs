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

    public void ShowSoundMenu()
    {
        soundMenu.SetActive(true);
    }

    public void ShowControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    public void ShowLevelDifficultyMenu()
    {
        levelDifficultyMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        if (soundMenu.activeInHierarchy) soundMenu.SetActive(false);
        if (controlsMenu.activeInHierarchy) controlsMenu.SetActive(false);
        if (levelDifficultyMenu.activeInHierarchy) levelDifficultyMenu.SetActive(false);
    }
}
