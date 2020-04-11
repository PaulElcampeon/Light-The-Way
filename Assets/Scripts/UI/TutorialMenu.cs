using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject aimClue;

    [SerializeField]
    private GameObject enemyClue;

    [SerializeField]
    private GameObject actionClue;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private GameObject gameWinScreen;

    [SerializeField]
    private GameObject inGameMenu;

    public bool isClueShowing;

    public static TutorialMenu instance;

    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) CloseActiveClue();
    }

    public void ShowAimClue()
    {
        aimClue.SetActive(true);
    }

    public void ShowEnemyClue()
    {
        enemyClue.SetActive(true);
    }

    public void ShowActionClue()
    {
        actionClue.SetActive(true);
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
        isClueShowing = true;
        GameManager.instance.Pause();
    }

    private void CloseActiveClue()
    {
        aimClue.SetActive(false);
        enemyClue.SetActive(false);
        actionClue.SetActive(false);
        GameManager.instance.UnPause();
        GameManager.instance.isMenuOpen = false;
        isClueShowing = false;
    }
}
