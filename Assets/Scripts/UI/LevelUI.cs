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

    public void CloseActivePanel()
    {
        SoundManager.instance.PlaySFX(1);

        if (gameOverScreen.activeInHierarchy) gameOverScreen.SetActive(false);
        if (gameWinScreen.activeInHierarchy) gameWinScreen.SetActive(false);
        if (inGameMenu.activeInHierarchy) inGameMenu.SetActive(false);

        GameManager.instance.UnPause();
        GameManager.instance.isMenuOpen = false;
    }
}
