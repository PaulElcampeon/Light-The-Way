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

    [SerializeField]
    private GameObject showScoresMenu;

    public void StartNewGame()
    {
        SoundManager.instance.PlaySFX(0);

        GameManager.instance.ResetSavedData();

        CustomSceneManager.instance.LoadScene("Tutorial");
    }

    public void ShowLevels()
    {
        SoundManager.instance.PlaySFX(0);

        levelSelector.SetActive(true);
    }

    public void LoadLevel(int level)
    {
        CustomSceneManager.instance.LoadScene(level.ToString());
    }

    public void ShowOptionsMenu()
    {
        SoundManager.instance.PlaySFX(0);

        optionsMenu.SetActive(true);
    }

    public void ShowScoresMenu()
    {
        SoundManager.instance.PlaySFX(0);

        showScoresMenu.SetActive(true);
    }

    public void ShowControlsOption()
    {
        SoundManager.instance.PlaySFX(0);

        controlOptions.SetActive(true);
    }

    public void ShowSoundOption()
    {
        SoundManager.instance.PlaySFX(0);
        soundOptions.SetActive(true);
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
        SoundManager.instance.PlaySFX(0);

        difficultyOptions.SetActive(false);
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

        if (showScoresMenu.activeInHierarchy)
        {
            showScoresMenu.SetActive(false);
            return;
        }
        optionsMenu.SetActive(false);
    }

    public void ShowCredits()
    {
        SoundManager.instance.PlaySFX(0);

        creditPanel.SetActive(true);
    }

    public void ExitGame()
    {
        SoundManager.instance.PlaySFX(1);

        GameManager.instance.ExitGame();
    }
}
