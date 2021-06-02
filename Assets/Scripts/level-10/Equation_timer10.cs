// Name: Equation_timer10.cs
// Purpose: Generates timer for equations of level 10
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations10.cs, Timer10.cs, playerMovement10.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer10 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 6f;
    public static float timeLeft10;

    playerMovement10 my_object;
    Timer10 time;


    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft10 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft10 > 0)
        {
            timeLeft10 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft10 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement10>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer10>();
            time.wrong_answer();

            timeLeft10 = myTime;
        }
    }
}