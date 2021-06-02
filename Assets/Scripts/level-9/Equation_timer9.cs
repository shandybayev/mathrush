// Name: Equation_timer9.cs
// Purpose: Generates timer for equations of level 9
// Version 2, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equations9.cs, Timer9.cs, playerMovement9.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equation_timer9 : MonoBehaviour
{

    Image timerBar;
    private float myTime = 6f;
    public static float timeLeft9;

    playerMovement9 my_object;
    Timer9 time;
    

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft9 = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft9 > 0)
        {
            timeLeft9 -= Time.deltaTime;
            timerBar.fillAmount = timeLeft9 / myTime;
        }
        else
        {
            my_object = FindObjectOfType<playerMovement9>();
            my_object.equationOff();

            my_object.show_red_screen();
            my_object.invoke_red_screen();

            time = FindObjectOfType<Timer9>();
            time.wrong_answer();

            timeLeft9 = myTime;
        }
    }
}