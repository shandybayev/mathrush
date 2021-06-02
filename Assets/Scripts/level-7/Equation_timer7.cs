// Name: Equation_timer7.cs
// Purpose: Generates timer for equations of level 7
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations7.cs, Timer7.cs, playerMovement7.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer7 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 5f;
    public static float timeLeft7;

    playerMovement7 my_object;
    Timer7 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft7 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft7 > 0)
        {
            timeLeft7 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft7 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement7>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer7>();
            time.wrong_answer();

            timeLeft7 = myTime;
        }
    }
}