// Name: Equation_timer5.cs
// Purpose: Generates timer for equations of level 5
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations5.cs, Timer5.cs, playerMovement5.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer5 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 5f;
    public static float timeLeft5;

    playerMovement5 my_object;
    Timer5 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft5 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft5 > 0)
        {
            timeLeft5 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft5 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement5>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer5>();
            time.wrong_answer();

            timeLeft5 = myTime;
        }
    }
}