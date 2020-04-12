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
        gameOverScreen.SetActive(true);
    }

    public void ShowGamWinScreen()
    {
        gameWinScreen.SetActive(true);
    }

    public void ShowInGameMenu()
    {
        inGameMenu.SetActive(true);
    }

    public void OpenMenuItem()
    {
        GameManager.instance.isMenuOpen = true;
        GameManager.instance.Pause();
    }

    public void CloseActivePanel()
    {
        if (gameOverScreen.activeInHierarchy) gameOverScreen.SetActive(false);
        if (gameWinScreen.activeInHierarchy) gameWinScreen.SetActive(false);
        if (inGameMenu.activeInHierarchy) inGameMenu.SetActive(false);
        GameManager.instance.UnPause();
        GameManager.instance.isMenuOpen = false;
    }
}
