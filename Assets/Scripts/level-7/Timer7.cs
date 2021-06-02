// Name: Timer7.cs
// Purpose: Creates timer for level 7
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement7.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer7 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft7;
    playerMovement7 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft7 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft7 > 0)
        {
            timeLeft7 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft7 / maTime;

            if (timeLeft7 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft7 >= maTime / 4)
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
            gameOver = FindObjectOfType<playerMovement7>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft7 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft7 + 5 < maTime)
            timeLeft7 += 5;
        else
            timeLeft7 = maTime;
    }
}