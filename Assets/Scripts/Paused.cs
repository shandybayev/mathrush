// Name: Paused.cs
// Purpose: Works to control the pause and info screens on all levels except level 1
// Version 3, April 11, 2021
// Author: Zhandos Shandybayev
// No dependencies 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject info;
    [SerializeField]
    GameObject equation_screen;

    private string scene_name;

    void Start()
    {
        pause.SetActive(false);
        info.SetActive(false);

        scene_name = SceneManager.GetActiveScene().name;
    }

    public void infoOn()
    {
        info.SetActive(true);
        Time.timeScale = 0;
    }

    public void infoOff()
    {
        info.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseOn()
    {
        pause.SetActive(true);
        equation_screen.SetActive(false);
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;

        if (playerMovement.on_equation == true)
            equation_screen.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(scene_name);
        Time.timeScale = 1;
    }
}
