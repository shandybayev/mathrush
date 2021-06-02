// Name: Timer2.cs
// Purpose: Creates timer for level 2
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement2.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft2;
    playerMovement2 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft2 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft2 > 0)
        {
            timeLeft2 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft2 / maTime;

            if (timeLeft2 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft2 >= maTime / 4)
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
            gameOver = FindObjectOfType<playerMovement2>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft2 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft2 + 5 < maTime)
            timeLeft2 += 5;
        else
            timeLeft2 = maTime;
    }
}