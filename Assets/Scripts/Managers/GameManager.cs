using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;

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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            Pause();

            //ResetScene();

            //UnPause();

            //isGameOver = false;
        }
    }

    private void ResetScene()
    {
       
    }

    private void CheckIfPlayerHasFallen()
    {
        if (Player.instance.transform.position.y <= -4.5) isGameOver = true;
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
