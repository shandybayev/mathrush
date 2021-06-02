// Name: Timer3.cs
// Purpose: Creates timer for level 3
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement3.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer3 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft3;
    playerMovement3 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft3 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft3 > 0)
        {
            timeLeft3 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft3 / maTime;

            if (timeLeft3 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft3 >= maTime / 4)
            {
                timerBar.color = Color.yellow;
            }
            else
            {
                timerBar.color = Color.red;
            }
        } else
        {
            counter++;
            gameOver = FindObjectOfType<playerMovement3>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft3 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft3 + 5 < maTime)
            timeLeft3 += 5;
        else
            timeLeft3 = maTime;
    }
}