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

    private void Start()
    {
        bgmSlider.value = SoundManager.instance.bgmVolume;
        sfxSlider.value = SoundManager.instance.sfxVolume;
    }

    void Update()
    {
        SoundManager.instance.bgmVolume = bgmSlider.value;
        SoundManager.instance.sfxVolume = sfxSlider.value;
    }

    public void UpdateBGMVolume()
    {
        SoundManager.instance.UpdateBGMVolume(bgmSlider.value);
    }

    public void UpdateSFXVolume()
    {
        SoundManager.instance.UpdateSFXVolume(sfxSlider.value);
    }
}
