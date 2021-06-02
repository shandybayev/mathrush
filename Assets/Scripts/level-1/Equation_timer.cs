// Name: Equation_timer.cs
// Purpose: Generates timer for equations of level 1
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations1.cs, Timer.cs, playerMovement.cs scripts


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer : MonoBehaviour
{

    Image timerBar;
    private float myTime = 5f;
    public static float timeLeft;

    playerMovement my_object;
    Timer time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer>();
            time.wrong_answer();

            timeLeft = myTime;
        }
    }
}