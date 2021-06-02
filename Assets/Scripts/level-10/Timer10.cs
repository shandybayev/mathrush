// Name: Timer10.cs
// Purpose: Creates timer for level 10
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement10.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer10 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 40f;
    float timeLeft10;
    playerMovement10 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft10 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft10 > 0)
        {
            timeLeft10 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft10 / maTime;

            if (timeLeft10 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft10 >= maTime / 4)
            {
                timerBar.color = Color.yellow;
            }
            else
            {
                timerBar.color = Color.red;
            }
        }
        else
        {
            counter++;
            gameOver = FindObjectOfType<playerMovement10>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer()
    {
        timeLeft10 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft10 + 6 < maTime)
            timeLeft10 += 6;
        else
            timeLeft10 = maTime;
    }
}