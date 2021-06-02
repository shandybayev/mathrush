// Name: Equation_timer6.cs
// Purpose: Generates timer for equations of level 6
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations6.cs, Timer6.cs, playerMovement6.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer6 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 5f;
    public static float timeLeft6;

    playerMovement6 my_object;
    Timer6 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft6 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft6 > 0)
        {
            timeLeft6 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft6 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement6>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer6>();
            time.wrong_answer();

            timeLeft6 = myTime;
        }
    }
}