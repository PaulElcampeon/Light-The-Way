using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject gameWinScreen;
    [SerializeField]
    private GameObject menu;

    public static GameManager instance;
    public bool isGameOver;
    public bool isLevelCompleted;
    public bool isMenuOpen;

    private int currentLevel;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameWinScreen.activeInHierarchy || gameOverScreen.activeInHierarchy) return;

        if (isGameOver && !gameOverScreen.activeInHierarchy)
        {
            StartCoroutine(ShowGameOverScreen());
        }

        if (isLevelCompleted && !gameWinScreen.activeInHierarchy)
        {
            StartCoroutine(ShowGameWinScreen());
        }
    }

    private IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(4);

        TutorialMenu.instance.OpenMenuItem();
        TutorialMenu.instance.ShowGameOverScreen();
    }

    private IEnumerator ShowGameWinScreen()
    {
        yield return new WaitForSeconds(4);

        TutorialMenu.instance.OpenMenuItem();
        TutorialMenu.instance.ShowGamWinScreen();
    }

    private void CheckIfPlayerHasFallen()
    {
        if (Player.instance.transform.position.y > -4.5) return;

        isGameOver = true;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public static GameManager getinstance()
    {
        return instance;
    }

    public void ExitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
