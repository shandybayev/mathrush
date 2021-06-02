// Name: Equations5.cs
// Purpose: Generates equations for level 5
// Version 6, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on MainMenu.cs, playerMovement5.cs, Timer5.cs, Equation_timer5.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Equations5 : MonoBehaviour
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

    Equation_timer5 my_timer;
    playerMovement5 my_object;
    Timer5 time;

    public void Start()
    {
        my_score = 0;
        high_score = 0;

        if (PlayerPrefs.HasKey("high_score5"))
        {
            high_score = PlayerPrefs.GetInt("high_score5");
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
        my_object = FindObjectOfType<playerMovement5>();
        my_object.equationOff();

        time = FindObjectOfType<Timer5>();
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
        my_object = FindObjectOfType<playerMovement5>();
        my_object.equationOff();

        time = FindObjectOfType<Timer5>();
        time.wrong_answer();

        my_object.show_red_screen();
        my_object.invoke_red_screen();
    }

    public void updateHighScore()
    {
        if (my_score >= high_score)
        {
            high_score = my_score;

            PlayerPrefs.SetInt("high_score5", high_score);
            PlayerPrefs.SetString("grade5", grade);
        }
    }

    public void showEquation()
    {
        equation.GetComponent<Equation_timer5>();
        Equation_timer5.timeLeft5 = 5f;

        posBut1 = but1.transform.position.y;
        posBut2 = but2.transform.position.y;
        posBut3 = but3.transform.position.y;
        posBut4 = but4.transform.position.y;

        int equationType = Random.Range(1, 3);

        if (equationType == 1)
        {
            List<int> ansList = new List<int>();

            int number1 = Random.Range(40, 151);
            int number2 = Random.Range(40, 151);
            int correct_ans = number1 + number2;

            ans_cor = correct_ans;

            ansList.Add(correct_ans);

            string totalText = number1.ToString() + " + " + number2.ToString() + " = ?";
            textEquation.GetComponent<Text>().text = totalText;

            int ans_choice = Random.Range(1, 5);

            if (ans_choice == 1)
            {
                ans1.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 3, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans2.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 2)
            {
                ans2.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 3, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 3)
            {
                ans3.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 3, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 4)
            {
                ans4.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 3, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans3.GetComponent<Text>().text = ansList[3].ToString();
            }
        } else
        {
            List<int> ansList = new List<int>();

            int number1 = Random.Range(50, 161);
            int number2 = Random.Range(30, number1 - 19);

            int correct_ans = number1 - number2;

            ans_cor = correct_ans;

            ansList.Add(correct_ans);

            string totalText = number1.ToString() + " - " + number2.ToString() + " = ?";
            textEquation.GetComponent<Text>().text = totalText;

            int ans_choice = Random.Range(1, 5);

            if (ans_choice == 1)
            {
                ans1.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 4, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans2.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 2)
            {
                ans2.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 4, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans3.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 3)
            {
                ans3.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 4, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans4.GetComponent<Text>().text = ansList[3].ToString();
            }
            else if (ans_choice == 4)
            {
                ans4.GetComponent<Text>().text = correct_ans.ToString();

                while (ansList.Count < 4)
                {
                    int chance_of_another_wrong_ans = Random.Range(1, 11);

                    if (chance_of_another_wrong_ans <= 6)
                    {
                        int wrong_ans = Random.Range(correct_ans - 4, correct_ans + 4);
                        if (!ansList.Contains(wrong_ans))
                            ansList.Add(wrong_ans);
                    }

                    int up = correct_ans + 10, down = correct_ans - 10;

                    for (int k = 1; k <= 3; ++k)
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
                }

                ans1.GetComponent<Text>().text = ansList[1].ToString();
                ans2.GetComponent<Text>().text = ansList[2].ToString();
                ans3.GetComponent<Text>().text = ansList[3].ToString();
            }
        }
    }
}
