// Name: Timer5.cs
// Purpose: Creates timer for level 5
// Version 4, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement5.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer5 : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft5;
    playerMovement5 gameOver;

    private int counter = 0;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft5 = maTime;

        timerBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft5 > 0)
        {
            timeLeft5 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft5 / maTime;

            if (timeLeft5 >= maTime / 2)
            {
                timerBar.color = Color.green;
            }
            else if (timeLeft5 >= maTime / 4)
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
            gameOver = FindObjectOfType<playerMovement5>();

            if (counter == 1)
                gameOver.game_over();
        }
    }

    public void play_again_time()
    {
        timerBar.fillAmount = 0;
    }

    public void wrong_answer() {
        timeLeft5 -= 4;
    }

    public void correct_answer()
    {
        if (timeLeft5 + 5 < maTime)
            timeLeft5 += 5;
        else
            timeLeft5 = maTime;
    }
}