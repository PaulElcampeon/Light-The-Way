using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    private bool hasShownAimClue;
    private bool hasShownActionClue;
    private bool hasShowEnemyClue;

    void Start()
    {
        StartCoroutine(DisplayAimClue());
    }

    void Update()
    {
        if (GameManager.instance.isLevelCompleted || GameManager.instance.isGameOver) return;

        if (Vector2.Distance(Player.instance.transform.position, enemy.transform.position) <= 3.5f && !hasShowEnemyClue) ShowEnemyClue();

        if (hasShownAimClue && !TutorialClues.instance.isClueShowing && !hasShownActionClue) StartCoroutine(DisplayActionClueClue());

    }

    public IEnumerator DisplayAimClue()
    {
        yield return new WaitForSeconds(2);

        TutorialClues.instance.OpenMenuItem();
        TutorialClues.instance.ShowAimClue();
        hasShownAimClue = true;
    }

    public IEnumerator DisplayActionClueClue()
    {
        hasShownActionClue = true;

        yield return new WaitForSeconds(2);

        TutorialClues.instance.OpenMenuItem();
        TutorialClues.instance.ShowActionClue();
    }

    public void ShowEnemyClue()
    {
        hasShowEnemyClue = true;

        TutorialClues.instance.OpenMenuItem();
        TutorialClues.instance.ShowEnemyClue();
    }
}
