// Name: Timer4.cs
// Purpose: Creates timer for level 4
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement4.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer4 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft4;
    playerMovement4 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft4 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft4 > 0)
        {
            timeLeft4 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft4 / maTime;

            if (timeLeft4 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft4 >= maTime / 4)
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
            gameOver = FindObjectOfType<playerMovement4>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft4 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft4 + 5 < maTime)
            timeLeft4 += 5;
        else
            timeLeft4 = maTime;
    }
}