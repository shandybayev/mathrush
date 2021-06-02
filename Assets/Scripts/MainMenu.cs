// Name: MainMenu.cs
// Purpose: Works to control the system on Main Menu
// Version 6, May 31, 2021
// Author: Zhandos Shandybayev
// Dependent on all Equations scripts 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject options;
    [SerializeField]
    GameObject info;
    [SerializeField]
    GameObject levels;

    public TMP_Text high_score1;
    public TMP_Text high_score2;
    public TMP_Text high_score3;
    public TMP_Text high_score4;
    public TMP_Text high_score5;
    public TMP_Text high_score6;
    public TMP_Text high_score7;
    public TMP_Text high_score8;
    public TMP_Text high_score9;
    public TMP_Text high_score10;

    void Start()
    {
        menu.SetActive(true);
        options.SetActive(false);
        info.SetActive(false);
        levels.SetActive(false);

        Camera cam = GetComponent<Camera>();
        cam.aspect = 16f / 9f;
    }

    private void Update()
    {
        high_score1.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade1");
        high_score2.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade2");
        high_score3.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade3");
        high_score4.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade4");
        high_score5.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade5");
        high_score6.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade6");
        high_score7.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade7");
        high_score8.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade8");
        high_score9.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade9");
        high_score10.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("grade10");
    }

    private void resetScores()
    {
        PlayerPrefs.SetString("grade1", "");
        PlayerPrefs.SetString("grade2", "");
        PlayerPrefs.SetString("grade3", "");
        PlayerPrefs.SetString("grade4", "");
        PlayerPrefs.SetString("grade5", "");
        PlayerPrefs.SetString("grade6", "");
        PlayerPrefs.SetString("grade7", "");
        PlayerPrefs.SetString("grade8", "");
        PlayerPrefs.SetString("grade9", "");
        PlayerPrefs.SetString("grade10", "");

        PlayerPrefs.SetInt("high_score1", 0);
        PlayerPrefs.SetInt("high_score2", 0);
        PlayerPrefs.SetInt("high_score3", 0);
        PlayerPrefs.SetInt("high_score4", 0);
        PlayerPrefs.SetInt("high_score5", 0);
        PlayerPrefs.SetInt("high_score6", 0);
        PlayerPrefs.SetInt("high_score7", 0);
        PlayerPrefs.SetInt("high_score8", 0);
        PlayerPrefs.SetInt("high_score9", 0);
        PlayerPrefs.SetInt("high_score10", 0);
    }

    public void levelsOn()
    {
        levels.SetActive(true);
        menu.SetActive(false);
    }

    public void levelsOff()
    {
        levels.SetActive(false);
        menu.SetActive(true);
    }

    public void infoOn()
    {
        info.SetActive(true);
        options.SetActive(false);
    }

    public void infoOff()
    {
        info.SetActive(false);
        options.SetActive(true);
    }

    public void optionsOn()
    {
        options.SetActive(true);
        menu.SetActive(false);
    }

    public void optionsOff()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }

    public void StartLevel1() {
        SceneManager.LoadScene("s");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("s2");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("s3");
    }

    public void StartLevel4()
    {
        SceneManager.LoadScene("s4");
    }

    public void StartLevel5()
    {
        SceneManager.LoadScene("s5");
    }

    public void StartLevel6()
    {
        SceneManager.LoadScene("s6");
    }

    public void StartLevel7()
    {
        SceneManager.LoadScene("s7");
    }

    public void StartLevel8()
    {
        SceneManager.LoadScene("s8");
    }

    public void StartLevel9()
    {
        SceneManager.LoadScene("s9");
    }

    public void StartLevel10()
    {
        SceneManager.LoadScene("s10");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
