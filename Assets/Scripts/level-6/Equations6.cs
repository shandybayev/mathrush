﻿// Name: Equations6.cs
// Purpose: Generates equations for level 6
// Version 6, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement6.cs, Timer6.cs, Equation_timer6.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Equations6 : MonoBehaviour
{
    public Text textEquation;
    public Text ans1;
    public Text ans2;
    public Text ans3;
    public Text ans4;
    public TMP_Text score;
    public TMP_Text finish_score;
    public TMP_Text play_again_score;
    public static int my_score = 0;
    public int high_score;
    private string grade;

    public GameObject but1;
    public GameObject but2;
    public GameObject but3;
    public GameObject but4;

    float posBut1;
    float posBut2;
    float posBut3;
    float posBut4;

    int ans_cor;

    [SerializeField]
    GameObject equation;

    Equation_timer6 my_timer;
    playerMovement6 my_object;
    Timer6 time;

    public void Start()
    {
        my_score = 0;
        high_score = 0;

        if (PlayerPrefs.HasKey("high_score6"))
        {
            high_score = PlayerPrefs.GetInt("high_score6");
        }
    }


    public void Update()
    {
        if (posBut1 != but1.transform.position.y)
        {
            if (ans1.GetComponent<Text>().text == ans_cor.ToString())
            {
                correctAns();
            }
            else
            {
                wrongAns();
            }
        }
        else if (posBut2 != but2.transform.position.y)
        {
            if (ans2.GetComponent<Text>().text == ans_cor.ToString())
            {
                correctAns();
            }
            else
            {
                wrongAns();
            }
        }
        else if (posBut3 != but3.transform.position.y)
        {
            if (ans3.GetComponent<Text>().text == ans_cor.ToString())
            {
                correctAns();
            }
            else
            {
                wrongAns();
            }
        }
        else if (posBut4 != but4.transform.position.y)
        {
            if (ans4.GetComponent<Text>().text == ans_cor.ToString())
            {
                correctAns();
            }
            else
            {
                wrongAns();
            }
        }

        if (my_score <= 50)
            grade = "F";
        else if (my_score == 60)
            grade = "D";
        else if (my_score == 70)
            grade = "C";
        else if (my_score == 80)
            grade = "B";
        else if (my_score == 90)
            grade = "A";
        else
            grade = "A+";

        updateHighScore();
    }

    public void setUp()
    {
        my_score = 0;
    }

    public void correctAns()
    {
        my_object = FindObjectOfType<playerMovement6>();
        my_object.equationOff();

        time = FindObjectOfType<Timer6>();
        time.correct_answer();

        my_object.show_green_screen();
        my_object.invoke_green_screen();

        my_score += 10;

        if (my_score <= 50)
            grade = "F";
        else if (my_score == 60)
            grade = "D";
        else if (my_score == 70)
            grade = "C";
        else if (my_score == 80)
            grade = "B";
        else if (my_score == 90)
            grade = "A";
        else
            grade = "A+";

        updateHighScore();

        score.GetComponent<TMP_Text>().text = my_score.ToString();
        finish_score.GetComponent<TMP_Text>().text = "SCORE: " + my_score.ToString() + " (" + grade + ")";
        play_again_score.GetComponent<TMP_Text>().text = "SCORE: " + my_score.ToString() + " (" + grade + ")";
    }

    public void wrongAns()
    {
        my_object = FindObjectOfType<playerMovement6>();
        my_object.equationOff();

        time = FindObjectOfType<Timer6>();
        time.wrong_answer();

        my_object.show_red_screen();
        my_object.invoke_red_screen();
    }

    public void updateHighScore()
    {
        if (my_score >= high_score)
        {
            high_score = my_score;

            PlayerPrefs.SetInt("high_score6", high_score);
            PlayerPrefs.SetString("grade6", grade);
        }
    }

    public void showEquation()
    {
        equation.GetComponent<Equation_timer6>();
        Equation_timer6.timeLeft6 = 5f;

        posBut1 = but1.transform.position.y;
        posBut2 = but2.transform.position.y;
        posBut3 = but3.transform.position.y;
        posBut4 = but4.transform.position.y;

        int equationType = Random.Range(1, 3);

        if (equationType == 1)
        {
            List<int> ansList = new List<int>();

            int number1 = Random.Range(7, 21);
            int number2 = Random.Range(7, 21);
            int correct_ans = number1 * number2;

            ans_cor = correct_ans;

            ansList.Add(correct_ans);

            string totalText = number1.ToString() + " x " + number2.ToString() + " = ?";
            textEquation.GetComponent<Text>().text = totalText;

            int ans_choice = Random.Range(1, 5);

            if (ans_choice == 1)
            {
                ans1.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    int divisibleNum = Random.Range(1, 3);

                    if (divisibleNum == 1)
                    {
                        int wrong_ans = number1 * Random.Range(number2 - 2, number2 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                    else
                    {
                        int wrong_ans = number2 * Random.Range(number1 - 2, number1 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                }

                ans2.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 2)
            {
                ans2.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    int divisibleNum = Random.Range(1, 3);

                    if (divisibleNum == 1)
                    {
                        int wrong_ans = number1 * Random.Range(number2 - 2, number2 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                    else
                    {
                        int wrong_ans = number2 * Random.Range(number1 - 2, number1 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 3)
            {
                ans3.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    int divisibleNum = Random.Range(1, 3);

                    if (divisibleNum == 1)
                    {
                        int wrong_ans = number1 * Random.Range(number2 - 2, number2 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                    else
                    {
                        int wrong_ans = number2 * Random.Range(number1 - 2, number1 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 4)
            {
                ans4.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    int divisibleNum = Random.Range(1, 3);

                    if (divisibleNum == 1)
                    {
                        int wrong_ans = number1 * Random.Range(number2 - 2, number2 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                    else
                    {
                        int wrong_ans = number2 * Random.Range(number1 - 2, number1 + 4);

                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans3.GetComponent<Text>().text = ansList[3].ToString();
            }
        } else
        {
            List<int> ansList = new List<int>();
            List<int> divisors = new List<int>();

            int number1 = Random.Range(7, 22);
            int number2 = Random.Range(7, 22);

            int total = number1 * number2;

            for (int i = 1; i <= total; ++i)
            {
                if (total % i == 0)
                    divisors.Add(i);
            }

            int index_for_cor = Random.Range(1, divisors.Count - 1);
            int correct_ans = divisors[index_for_cor];

            ans_cor = correct_ans;

            ansList.Add(correct_ans);

            string totalText = total.ToString() + " / " + (total / correct_ans).ToString() + " = ?";
            textEquation.GetComponent<Text>().text = totalText;

            int ans_choice = Random.Range(1, 5);

            if (ans_choice == 1)
            {
                ans1.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            if (!ansList.Contains(up))
                                ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                if (!ansList.Contains(down))
                                    ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                if (!ansList.Contains(up))
                                    ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    if (divisors.Count == 3)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);

                        int random_wrong_answer = Random.Range(correct_ans - 2, correct_ans + 3);
                        if (!ansList.Contains(random_wrong_answer))
                            ansList.Add(random_wrong_answer);
                    }
                    else if (divisors.Count == 4)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);
                        if (!ansList.Contains(divisors[2]))
                            ansList.Add(divisors[2]);
                    }
                    else
                    {
                        if (index_for_cor <= 2)
                        {
                            int index_for_wrong = Random.Range(1, 6);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 2)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 4, index_for_cor + 1);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 3)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 2);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 3);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                    }

                    int random_wrong_ans = Random.Range(correct_ans - 2, correct_ans + 3);
                    if (!ansList.Contains(random_wrong_ans))
                        ansList.Add(random_wrong_ans);
                }

                ans2.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 2)
            {
                ans2.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            if (!ansList.Contains(up))
                                ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                if (!ansList.Contains(down))
                                    ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                if (!ansList.Contains(up))
                                    ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    if (divisors.Count == 3)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);

                        int random_wrong_answer = Random.Range(correct_ans - 2, correct_ans + 3);
                        if (!ansList.Contains(random_wrong_answer))
                            ansList.Add(random_wrong_answer);
                    }
                    else if (divisors.Count == 4)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);
                        if (!ansList.Contains(divisors[2]))
                            ansList.Add(divisors[2]);
                    }
                    else
                    {
                        if (index_for_cor <= 2)
                        {
                            int index_for_wrong = Random.Range(1, 6);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 2)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 4, index_for_cor + 1);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 3)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 2);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 3);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                    }

                    int random_wrong_ans = Random.Range(correct_ans - 2, correct_ans + 3);
                    if (!ansList.Contains(random_wrong_ans))
                        ansList.Add(random_wrong_ans);
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 3)
            {
                ans3.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            if (!ansList.Contains(up))
                                ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                if (!ansList.Contains(down))
                                    ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                if (!ansList.Contains(up))
                                    ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    if (divisors.Count == 3)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);

                        int random_wrong_answer = Random.Range(correct_ans - 2, correct_ans + 3);
                        if (!ansList.Contains(random_wrong_answer))
                            ansList.Add(random_wrong_answer);
                    }
                    else if (divisors.Count == 4)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);
                        if (!ansList.Contains(divisors[2]))
                            ansList.Add(divisors[2]);
                    }
                    else
                    {
                        if (index_for_cor <= 2)
                        {
                            int index_for_wrong = Random.Range(1, 6);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 2)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 4, index_for_cor + 1);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 3)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 2);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 3);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                    }

                    int random_wrong_ans = Random.Range(correct_ans - 2, correct_ans + 3);
                    if (!ansList.Contains(random_wrong_ans))
                        ansList.Add(random_wrong_ans);
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 4)
            {
                ans4.GetComponent<Text>().text = correct_ans.ToString();

                int up = correct_ans + 10, down = correct_ans - 10;

                while (ansList.Count < 4)
                {
                    int random_decider = Random.Range(1, 11);

                    if (random_decider <= 4)
                    {
                        int random_choice = Random.Range(1, 3);

                        if (random_choice == 1)
                        {
                            if (!ansList.Contains(up))
                                ansList.Add(up);
                            up += 10;
                        }
                        else
                        {
                            if (down > 0)
                            {
                                if (!ansList.Contains(down))
                                    ansList.Add(down);
                                down -= 10;
                            }
                            else
                            {
                                if (!ansList.Contains(up))
                                    ansList.Add(up);
                                up += 10;
                            }
                        }
                    }

                    if (divisors.Count == 3)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);

                        int random_wrong_answer = Random.Range(correct_ans - 2, correct_ans + 3);
                        if (!ansList.Contains(random_wrong_answer))
                            ansList.Add(random_wrong_answer);
                    }
                    else if (divisors.Count == 4)
                    {
                        if (!ansList.Contains(divisors[1]))
                            ansList.Add(divisors[1]);
                        if (!ansList.Contains(divisors[2]))
                            ansList.Add(divisors[2]);
                    }
                    else
                    {
                        if (index_for_cor <= 2)
                        {
                            int index_for_wrong = Random.Range(1, 6);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 2)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 4, index_for_cor + 1);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else if (index_for_cor == divisors.Count - 3)
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 2);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                        else
                        {
                            int index_for_wrong = Random.Range(index_for_cor - 3, index_for_cor + 3);
                            int wrong_ans = divisors[index_for_wrong];

                            if (!ansList.Contains(wrong_ans))
                                ansList.Add(wrong_ans);
                        }
                    }

                    int random_wrong_ans = Random.Range(correct_ans - 2, correct_ans + 3);
                    if (!ansList.Contains(random_wrong_ans))
                        ansList.Add(random_wrong_ans);
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans3.GetComponent<Text>().text = ansList[3].ToString();
            }
        }
    }
}