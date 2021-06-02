// Name: Equation_timer4.cs
// Purpose: Generates timer for equations of level 4
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations4.cs, Timer4.cs, playerMovement4.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer4 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 5f;
    public static float timeLeft4;

    playerMovement4 my_object;
    Timer4 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft4 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft4 > 0)
        {
            timeLeft4 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft4 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement4>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer4>();
            time.wrong_answer();

            timeLeft4 = myTime;
        }
    }
}