using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresUI : MonoBehaviour
{
    [Header("Scores")]
    [SerializeField]
    private Button[] levelSelectorButtons;

    [SerializeField]
    private GameObject warningText;

    void Start()
    {
        int lastLevel = GameManager.instance.GetLastLevel();

        if (lastLevel > 0)
        {
            float[] scores = GameManager.instance.scores;

            warningText.SetActive(false);

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] == 0f) levelSelectorButtons[i-1].gameObject.SetActive(false);

                if (scores[i] != 0f)
                {
                    levelSelectorButtons[i - 1].gameObject.SetActive(true);
                    levelSelectorButtons[i-1].GetComponentInChildren<Text>().text = "LEVEL " + i + ": " + (Mathf.Round(scores[i] * 100) / 100.0).ToString() + " seconds";
                }
            }
        }
    }

    public void Close()
    {
        SoundManager.instance.PlaySFX(1);
        gameObject.SetActive(false);
    }
}
