using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [Header("Sound sliders")]
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider sfxSlider;

    void Update()
    {
        SoundManager.instance.SetBGMVolume(bgmSlider.value);
        SoundManager.instance.SetSFXVolume(sfxSlider.value);
    }
}
