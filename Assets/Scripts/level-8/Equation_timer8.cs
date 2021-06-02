// Name: Equation_timer8.cs
// Purpose: Generates timer for equations of level 8
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations8.cs, Timer8.cs, playerMovement8.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer8 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 7f;
    public static float timeLeft8;

    playerMovement8 my_object;
    Timer8 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft8 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft8 > 0)
        {
            timeLeft8 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft8 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement8>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer8>();
            time.wrong_answer();

            timeLeft8 = myTime;
        }
    }
}