// Name: level_controller.cs
// Purpose: Works to control the levels on level screen
// Version 5, May 20, 2021
// Author: Zhandos Shandybayev
// Dependent on all playerMovement scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_controller : MonoBehaviour
{
    public static bool isOpen2;
    public static bool isOpen3;
    public static bool isOpen4;
    public static bool isOpen5;
    public static bool isOpen6;
    public static bool isOpen7;
    public static bool isOpen8;
    public static bool isOpen9;
    public static bool isOpen10;

    public GameObject open2;
    public GameObject closed2;
    public GameObject open3;
    public GameObject closed3;
    public GameObject open4;
    public GameObject closed4;
    public GameObject open5;
    public GameObject closed5;
    public GameObject open6;
    public GameObject closed6;
    public GameObject open7;
    public GameObject closed7;
    public GameObject open8;
    public GameObject closed8;
    public GameObject open9;
    public GameObject closed9;
    public GameObject open10;
    public GameObject closed10;

    void Start()
    {
        isOpen2 = PlayerPrefs.GetInt("open2") == 1;
        isOpen3 = PlayerPrefs.GetInt("open3") == 1;
        isOpen4 = PlayerPrefs.GetInt("open4") == 1;
        isOpen5 = PlayerPrefs.GetInt("open5") == 1;
        isOpen6 = PlayerPrefs.GetInt("open6") == 1;
        isOpen7 = PlayerPrefs.GetInt("open7") == 1;
        isOpen8 = PlayerPrefs.GetInt("open8") == 1;
        isOpen9 = PlayerPrefs.GetInt("open9") == 1;
        isOpen10 = PlayerPrefs.GetInt("open10") == 1;

        open2.SetActive(isOpen2);
        closed2.SetActive(!isOpen2);

        open3.SetActive(isOpen3);
        closed3.SetActive(!isOpen3);

        open4.SetActive(isOpen4);
        closed4.SetActive(!isOpen4);

        open5.SetActive(isOpen5);
        closed5.SetActive(!isOpen5);

        open6.SetActive(isOpen6);
        closed6.SetActive(!isOpen6);

        open7.SetActive(isOpen7);
        closed7.SetActive(!isOpen7);

        open8.SetActive(isOpen8);
        closed8.SetActive(!isOpen8);

        open9.SetActive(isOpen9);
        closed9.SetActive(!isOpen9);

        open10.SetActive(isOpen10);
        closed10.SetActive(!isOpen10);
    }

    private void resetLevels()
    {
        isOpen2 = false;
        PlayerPrefs.SetInt("open2", isOpen2 ? 1 : 0);

        isOpen3 = false;
        PlayerPrefs.SetInt("open3", isOpen3 ? 1 : 0);

        isOpen4 = false;
        PlayerPrefs.SetInt("open4", isOpen4 ? 1 : 0);

        isOpen5 = false;
        PlayerPrefs.SetInt("open5", isOpen5 ? 1 : 0);

        isOpen6 = false;
        PlayerPrefs.SetInt("open6", isOpen6 ? 1 : 0);

        isOpen7 = false;
        PlayerPrefs.SetInt("open7", isOpen7 ? 1 : 0);

        isOpen8 = false;
        PlayerPrefs.SetInt("open8", isOpen8 ? 1 : 0);

        isOpen9 = false;
        PlayerPrefs.SetInt("open9", isOpen9 ? 1 : 0);

        isOpen10 = false;
        PlayerPrefs.SetInt("open10", isOpen10 ? 1 : 0);
    }

    public void openLevel2()
    {
        isOpen2 = true;
        PlayerPrefs.SetInt("open2", isOpen2 ? 1 : 0);
    }

    public void openLevel3()
    {
        isOpen3 = true;
        PlayerPrefs.SetInt("open3", isOpen3 ? 1 : 0);
    }

    public void openLevel4()
    {
        isOpen4 = true;
        PlayerPrefs.SetInt("open4", isOpen4 ? 1 : 0);
    }

    public void openLevel5()
    {
        isOpen5 = true;
        PlayerPrefs.SetInt("open5", isOpen5 ? 1 : 0);
    }

    public void openLevel6()
    {
        isOpen6 = true;
        PlayerPrefs.SetInt("open6", isOpen6 ? 1 : 0);
    }

    public void openLevel7()
    {
        isOpen7 = true;
        PlayerPrefs.SetInt("open7", isOpen7 ? 1 : 0);
    }

    public void openLevel8()
    {
        isOpen8 = true;
        PlayerPrefs.SetInt("open8", isOpen8 ? 1 : 0);
    }

    public void openLevel9()
    {
        isOpen9 = true;
        PlayerPrefs.SetInt("open9", isOpen9 ? 1 : 0);
    }

    public void openLevel10()
    {
        isOpen10 = true;
        PlayerPrefs.SetInt("open10", isOpen10 ? 1 : 0);
    }

    public void play_button()
    {
        if (isOpen2 == true)
        {
            open2.SetActive(true);
            closed2.SetActive(false);
        }
        else
        {
            open2.SetActive(false);
            closed2.SetActive(true);
        }

        if (isOpen3 == true)
        {
            open3.SetActive(true);
            closed3.SetActive(false);
        }
        else
        {
            open3.SetActive(false);
            closed3.SetActive(true);
        }

        if (isOpen4 == true)
        {
            open4.SetActive(true);
            closed4.SetActive(false);
        }
        else
        {
            open4.SetActive(false);
            closed4.SetActive(true);
        }

        if (isOpen5 == true)
        {
            open5.SetActive(true);
            closed5.SetActive(false);
        }
        else
        {
            open5.SetActive(false);
            closed5.SetActive(true);
        }

        if (isOpen6 == true)
        {
            open6.SetActive(true);
            closed6.SetActive(false);
        }
        else
        {
            open6.SetActive(false);
            closed6.SetActive(true);
        }

        if (isOpen7 == true)
        {
            open7.SetActive(true);
            closed7.SetActive(false);
        }
        else
        {
            open7.SetActive(false);
            closed7.SetActive(true);
        }

        if (isOpen8 == true)
        {
            open8.SetActive(true);
            closed8.SetActive(false);
        }
        else
        {
            open8.SetActive(false);
            closed8.SetActive(true);
        }

        if (isOpen9 == true)
        {
            open9.SetActive(true);
            closed9.SetActive(false);
        }
        else
        {
            open9.SetActive(false);
            closed9.SetActive(true);
        }

        if (isOpen10 == true)
        {
            open10.SetActive(true);
            closed10.SetActive(false);
        }
        else
        {
            open10.SetActive(false);
            closed10.SetActive(true);
        }
    }
}
