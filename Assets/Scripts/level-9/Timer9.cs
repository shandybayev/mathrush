// Name: Timer9.cs
// Purpose: Creates timer for level 9
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement9.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer9 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 35f;
    float timeLeft9;
    playerMovement9 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft9 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft9 > 0)
        {
            timeLeft9 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft9 / maTime;

            if (timeLeft9 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft9 >= maTime / 4)
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
            gameOver = FindObjectOfType<playerMovement9>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft9 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft9 + 6 < maTime)
            timeLeft9 += 6;
        else
            timeLeft9 = maTime;
    }
}