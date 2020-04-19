using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    public float timeTaken;
    public bool shouldStop;

    public static Timer instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (shouldStop) return;

        timeTaken += Time.deltaTime;

        UpdateText();
    }

    private void UpdateText()
    {
        timerText.text = (Mathf.Round(timeTaken * 100) / 100.0).ToString();
    }
}
