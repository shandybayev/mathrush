// Name: Timer8.cs
// Purpose: Creates timer for level 8
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement8.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer8 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 35f;
    float timeLeft8;
    playerMovement8 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft8 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft8 > 0)
        {
            timeLeft8 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft8 / maTime;

            if (timeLeft8 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft8 >= maTime / 4)
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
            gameOver = FindObjectOfType<playerMovement8>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft8 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft8 + 6 < maTime)
            timeLeft8 += 6;
        else
            timeLeft8 = maTime;
    }
}