﻿using System.Collections;
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

    [SerializeField]
    private GameObject[] lightsHUD;

    public bool isGameOver;
    public bool isLevelCompleted;
    public bool isMenuOpen;

    public int currentLevel;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (LevelHolder.instance != null) currentLevel = LevelHolder.instance.level;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && CustomSceneManager.instance.CurrentScene() != "Main Menu") ShowGameMenu();

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

    private void ShowGameMenu()
    {
        menu.SetActive(true);
        Pause();
    }

    private void CheckIfPlayerHasFallen()
    {
        if (Player.instance == null) return;
        if (Player.instance.transform.position.y > -6) return;

        isGameOver = true;
    }

    public void UpdateLightsHud(int numberOfLightsLeft)
    {
        for (int i=0; i < lightsHUD.Length; i++)
        {
            if (i>= numberOfLightsLeft)
            {
                lightsHUD[i].SetActive(false);
            }
        }
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

    public void Save()
    {
        if (currentLevel >= 9) return;

        if (PlayerPrefs.GetInt("currentLevel") > currentLevel) return;

        PlayerPrefs.SetInt("currentLevel", currentLevel+1);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public void Load()
    {
        Debug.Log(PlayerPrefs.HasKey("currentLevel"));

        if (PlayerPrefs.HasKey("currentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("currentLevel");
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    public int GetLastLevel()
    {
        if (PlayerPrefs.HasKey("currentLevel")) return PlayerPrefs.GetInt("currentLevel");

        return 0;
    }

    public void ResetSavedData()
    {
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            PlayerPrefs.DeleteKey("currentLevel");
            Debug.Log("Game data reset!");
        }
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
