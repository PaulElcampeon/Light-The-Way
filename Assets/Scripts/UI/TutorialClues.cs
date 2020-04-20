using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialClues : MonoBehaviour
{
    [SerializeField]
    private GameObject aimClue;
    [SerializeField]

    private GameObject enemyClue;
    [SerializeField]

    private GameObject actionClue;

    public bool isClueShowing;

    public static TutorialClues instance;

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

    public void OpenMenuItem()
    {
        SoundManager.instance.PlaySFX(0);

        isClueShowing = true;

        GameManager.instance.isMenuOpen = true;
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
