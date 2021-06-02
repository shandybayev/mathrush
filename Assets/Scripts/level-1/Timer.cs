﻿// Name: Timer.cs
// Purpose: Creates timer for level 1
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft;
    playerMovement gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maTime;

            if(timeLeft >= maTime / 2)
            {
                timerBar.color = Color.green;
            } else if(timeLeft >= maTime / 4)
            {
                timerBar.color = Color.yellow;
            } else
            {
                timerBar.color = Color.red;
            }
        } else
        {
            counter++;
            gameOver = FindObjectOfType<playerMovement>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft + 5 < maTime)
            timeLeft += 5;
        else
            timeLeft = maTime;
    }
}