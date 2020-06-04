using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private GameObject gameWinScreen;

    [SerializeField]
    private GameObject inGameMenu;

    [SerializeField]
    private GameObject nextLevelButton;

    public static LevelUI instance;

    void Start()
    {
        instance = this;
    }

    public void ShowGameOverScreen()
    {
        SoundManager.instance.StopCurrentBGM();

        /*No sound for game over screen as we already have the death sound playing*/
        gameOverScreen.SetActive(true);
    }

    public void ShowGamWinScreen()
    {
        SoundManager.instance.StopCurrentBGM();
        SoundManager.instance.PlaySFX(0);
       
        gameWinScreen.SetActive(true);

        if (LevelHolder.instance.level == 9) nextLevelButton.SetActive(false);
    }

    public void ShowInGameMenu()
    {
        SoundManager.instance.PlaySFX(0);

        inGameMenu.SetActive(true);
    }

    public void OpenMenuItem()
    {
        SoundManager.instance.PlaySFX(0);

        GameManager.instance.isMenuOpen = true;
        GameManager.instance.Pause();
    }

    public void LoadNextLevel()
    {
        GameManager.instance.LoadNextLevel();
    }
}
