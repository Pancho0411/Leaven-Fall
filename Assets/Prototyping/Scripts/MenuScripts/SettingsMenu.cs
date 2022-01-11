using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {

    //variable
    public AudioMixer audioMixer;

    private void Start()
    {
        //sets resolution to current screen resolution
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreen);
    }

    //changes master volume output
    public void SetMasterVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //changes SFX volume output
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXvolume", volume);
    }

    //toggles fullscreen
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //toggles v-sync
    public void SetVSync(bool VSyncOn)
    {
        if (!VSyncOn)
        {
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = 1;
        }
    }
}
