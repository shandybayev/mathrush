// Name: Timer6.cs
// Purpose: Creates timer for level 6
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement6.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer6 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft6;
    playerMovement6 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft6 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft6 > 0)
        {
            timeLeft6 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft6 / maTime;

            if (timeLeft6 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft6 >= maTime / 4)
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
            gameOver = FindObjectOfType<playerMovement6>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft6 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft6 + 5 < maTime)
            timeLeft6 += 5;
        else
            timeLeft6 = maTime;
    }
}