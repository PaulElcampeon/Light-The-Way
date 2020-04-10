using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        
    }


    public void StartNewGame()
    {
        CustomSceneManager.instance.LoadScene("Tutorial");
    }

    public void ShowLevels()
    {

    }

    public void LoadLevel(int level)
    {
        CustomSceneManager.instance.LoadScene(level.ToString());

    }

    public void ShowOptionsMenu()
    {

    }

    public void ShowControlsOption()
    {

    }

    public void ShowSoundOption()
    {

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

    }

    public void SetDifficulty(int difficultyLevel)
    {
        Debug.Log("Difficulty is now " + difficultyLevel);
    }

    public void CloseActivePanel()
    {
        Debug.Log("Heading Back");
    }

    public void ShowCredits()
    {

    }

    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
