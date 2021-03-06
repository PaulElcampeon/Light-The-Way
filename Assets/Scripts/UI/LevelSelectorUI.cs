﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorUI : MonoBehaviour
{
    [Header("Level Selector Buttons")]
    [SerializeField]
    private GameObject[] levelSelectorButtons;

    [SerializeField]
    private GameObject warningText;

    void Start()
    {
        int lastLevel = GameManager.instance.GetLastLevel();

        if (lastLevel > 0)
        {
            warningText.SetActive(false);

            for (int i = 0; i < levelSelectorButtons.Length; i++)
            {
                if (lastLevel > i)
                {
                    levelSelectorButtons[i].SetActive(true);
                }
                else
                {
                    levelSelectorButtons[i].SetActive(false);
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
