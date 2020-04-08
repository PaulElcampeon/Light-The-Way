using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound Effect Sounds")]
    [SerializeField]
    private AudioSource[] sfxSounds;

    [Header("Back Ground Music Sounds")]
    [SerializeField]
    private AudioSource[] bgmSounds;

    [Header("Volume Control")]
    [SerializeField]
    private float sfxVolume;
    [SerializeField]
    private float bgmVolume;

    public static SoundManager instance;

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

    public void PlaySFX(int sfxIndex)
    {
        AudioSource sound = sfxSounds[sfxIndex];

        sound.volume = sfxVolume;
        sound.Play();
    }

    public void PlayBGM(int bgmIndex)
    {
        AudioSource sound = bgmSounds[bgmIndex];

        sound.volume = bgmVolume;
        sound.Play();
    }

    public void SetSFXVolume(float volume)
    {
        if (!CheckIfVolumeInputIsCorrect(volume)) return;

        sfxVolume = volume;
    }

    public void SetBGMVolume(float volume)
    {
        if (!CheckIfVolumeInputIsCorrect(volume)) return;

        bgmVolume = volume;
    }

    public bool CheckIfVolumeInputIsCorrect(float volume)
    {
        if (volume < 0 || volume > 1)
        {
            Debug.LogError("Volume has to be between 0 and 1");
            return false;
        }
        return true;
    }

    public static SoundManager Getinstance()
    {
        return instance;
    }
}
