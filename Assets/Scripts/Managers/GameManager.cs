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

    public bool isGameOver;
    public bool isLevelCompleted;
    public bool isMenuOpen;

    private int currentLevel;

    public static GameManager instance;

    private void Start()
    {
        instance = this;

        if (LevelHolder.instance != null) currentLevel = LevelHolder.instance.level;
    }

    void Update()
    {
        if (gameWinScreen.activeInHierarchy || gameOverScreen.activeInHierarchy) return;

        CheckIfPlayerHasFallen();

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
        yield return new WaitForSeconds(3f);

        LevelUI.instance.OpenMenuItem();
        LevelUI.instance.ShowGameOverScreen();
    }

    private IEnumerator ShowGameWinScreen()
    {
        yield return new WaitForSeconds(4f);

        LevelUI.instance.OpenMenuItem();
        LevelUI.instance.ShowGamWinScreen();
    }

    private void CheckIfPlayerHasFallen()
    {
        if (Player.instance == null) return;
        if (Player.instance.transform.position.y > -5) return;

        isGameOver = true;
    }

    public void BackToMainMenu()
    {
        UnPause();
        CustomSceneManager.instance.LoadScene("Main Menu");
    }

    public void LoadNextLevel()
    {
        UnPause();
        CustomSceneManager.instance.LoadScene((currentLevel+1).ToString());
    }

    public void ResetLevel()
    {
        UnPause();
        CustomSceneManager.instance.ResetScene();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
