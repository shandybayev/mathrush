// Name: Mute.cs
// Purpose: Works to control the audio system
// Version 3, February 28, 2021
// Author: Zhandos Shandybayev
// No dependencies 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    private bool isMute;
    public GameObject mutedButton;
    public GameObject unmutedButton;

    void Start()
    {
        isMute = PlayerPrefs.GetInt("Mute") == 1;
        AudioListener.pause = isMute;

        unmutedButton.SetActive(!isMute);
        mutedButton.SetActive(isMute);
    }


    public void MuteButton()
    {
        isMute = !isMute;
        AudioListener.pause = isMute;
        PlayerPrefs.SetInt("Mute", isMute ? 1 : 0);
    }

    public void HideUnmutedButton()
    {
        unmutedButton.SetActive(false);
        mutedButton.SetActive(true);
    }

    public void HideMutedButton()
    {
        unmutedButton.SetActive(true);
        mutedButton.SetActive(false);
    }
}
