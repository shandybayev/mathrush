// Name: Equation_timer3.cs
// Purpose: Generates timer for equations of level 3
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations3.cs, Timer3.cs, playerMovement3.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer3 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 5f;
    public static float timeLeft3;

    playerMovement3 my_object;
    Timer3 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft3 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft3 > 0)
        {
            timeLeft3 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft3 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement3>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer3>();
            time.wrong_answer();

            timeLeft3 = myTime;
        }
    }
}