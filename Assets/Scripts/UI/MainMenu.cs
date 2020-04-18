using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private GameObject levelSelector;

    [SerializeField]
    private GameObject soundOptions;

    [SerializeField]
    private GameObject controlOptions;

    [SerializeField]
    private GameObject difficultyOptions;

    [SerializeField]
    private GameObject creditPanel;

    public void StartNewGame()
    {
        CustomSceneManager.instance.LoadScene("Tutorial");
        SoundManager.instance.PlaySFX(0);
    }

    public void ShowLevels()
    {
        levelSelector.SetActive(true);
        SoundManager.instance.PlaySFX(0);
    }

    public void LoadLevel(int level)
    {
        CustomSceneManager.instance.LoadScene(level.ToString());
    }

    public void ShowOptionsMenu()
    {
        optionsMenu.SetActive(true);
        SoundManager.instance.PlaySFX(0);
    }

    public void ShowControlsOption()
    {
        controlOptions.SetActive(true);
        SoundManager.instance.PlaySFX(0);
    }

    public void ShowSoundOption()
    {
        soundOptions.SetActive(true);
        SoundManager.instance.PlaySFX(0);
    }

    public void SetBgmVolume()
    {
        Debug.Log("Setting BGM Volume");
    }

    public void SetSfxVolume()
    {
        Debug.Log("Setting SFX Volume");
    }

    public void ShowDifficultyOption()
    {
        difficultyOptions.SetActive(false);
        SoundManager.instance.PlaySFX(0);
    }

    public void SetDifficulty(int difficultyLevel)
    {
        Debug.Log("Difficulty is now " + difficultyLevel);
    }

    public void CloseActivePanel()
    {
        SoundManager.instance.PlaySFX(1);

        if (levelSelector.activeInHierarchy)
        {
            levelSelector.SetActive(false);
            return;
        }

        if (soundOptions.activeInHierarchy)
        {
            soundOptions.SetActive(false);
            return;
        }

        if (controlOptions.activeInHierarchy)
        {
            controlOptions.SetActive(false);
            return;
        }

        if (difficultyOptions.activeInHierarchy)
        {
            difficultyOptions.SetActive(false);
            return;
        }

        if (creditPanel.activeInHierarchy)
        {
            creditPanel.SetActive(false);
            return;
        }
        optionsMenu.SetActive(false);
    }

    public void ShowCredits()
    {
        creditPanel.SetActive(true);
        SoundManager.instance.PlaySFX(0);
    }

    public void ExitGame()
    {
        SoundManager.instance.PlaySFX(0);
        GameManager.instance.ExitGame();
    }
}
