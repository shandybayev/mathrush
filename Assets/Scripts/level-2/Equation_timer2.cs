// Name: Equation_timer2.cs
// Purpose: Generates timer for equations of level 2
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations2.cs, Timer2.cs, playerMovement2.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer2 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 5f;
    public static float timeLeft2;

    playerMovement2 my_object;
    Timer2 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft2 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft2 > 0)
        {
            timeLeft2 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft2 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement2>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer2>();
            time.wrong_answer();

            timeLeft2 = myTime;
        }
    }
}