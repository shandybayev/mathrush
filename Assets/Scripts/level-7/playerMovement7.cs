// Name: playerMovement7.cs
// Purpose: Allows the player to move
// Version 5, May 31 2021
// Authors: Zhandos Shandybayev, Peter Gallogly, Ryan Anderson
// Dependent on Equation_timer7.cs, Timer7.cs, Equations7.cs, level_controller.cs scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement7 : MonoBehaviour {
    private float movementSpeed = 12f;
    private float copy_of_speed;
    public Rigidbody2D rb;

    [SerializeField]
    GameObject equation;
    [SerializeField]
    GameObject finish;
    [SerializeField]
    GameObject play_again;

    public GameObject next_level;

    public Animator tran1;

    public AudioSource win;
    public AudioSource background_music;
    public AudioSource lose;

    public GameObject red_screen;
    public GameObject green_screen;

    Equations7 my_object;
    Equation_timer7 my_timer;
    Timer7 timer_end;
    level_controller level7;

    float mx;

    void Start()
    {
        movementSpeed = 12f;
        GetComponent<Animator>().speed = 1;
        Time.timeScale = 1;
        copy_of_speed = movementSpeed;
        equation.SetActive(false);
        finish.SetActive(false);
        play_again.SetActive(false);
        red_screen.SetActive(false);
        green_screen.SetActive(false);

        my_object = FindObjectOfType<Equations7>();
        my_object.setUp();

        next_level.SetActive(false);

        playerMovement.on_equation = false;
    }

    public void Update()
    {
        mx = 1f;

        if (mx > 0f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
        else if (mx < 0f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
        }
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "block")
        {
            playerMovement.on_equation = true;
            Destroy(collision.gameObject);
            movementSpeed = 0f;
            GetComponent<Animator>().speed = 0;
            equation.SetActive(true);
            my_object = FindObjectOfType<Equations7>();
            my_object.showEquation();
        }

        if (collision.gameObject.name == "finish")
        {
            Destroy(collision.gameObject);
            movementSpeed = 0f;
            GetComponent<Animator>().speed = 0;
            Time.timeScale = 0;
            finish.SetActive(true);

            win.Play();
            background_music.Stop();

            if (Equations7.my_score >= 70)
            {
                next_level.SetActive(true);

                level_controller.isOpen8 = true;
                PlayerPrefs.SetInt("open8", level_controller.isOpen8 ? 1 : 0);
            } else
                next_level.SetActive(false);
        }
        if (collision.gameObject.name == "tran1")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition1", true);
        }
        if (collision.gameObject.name == "tran2")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition2", true);
        }
        if (collision.gameObject.name == "tran3")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition3", true);
        }
        if (collision.gameObject.name == "tran4")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition4", true);
        }
        if (collision.gameObject.name == "tran5")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition5", true);
        }
        if (collision.gameObject.name == "tran6")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition6", true);
        }
        if (collision.gameObject.name == "tran7")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition7", true);
        }
        if (collision.gameObject.name == "tran8")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition8", true);
        }
        if (collision.gameObject.name == "tran9")
        {
            Destroy(collision.gameObject);
            tran1.SetBool("transition9", true);
        }
    } 

    public void equationOff()
    {
        playerMovement.on_equation = false;
        equation.SetActive(false);
        movementSpeed = copy_of_speed;
        GetComponent<Animator>().speed = 1;
    }

    public void game_over()
    {
        timer_end = FindObjectOfType<Timer7>();
        timer_end.play_again_time();

        off_red_screen();

        movementSpeed = 0f;
        GetComponent<Animator>().speed = 0;
        Time.timeScale = 0;
        play_again.SetActive(true);

        lose.Play();
        background_music.Stop();
    }

    public void show_red_screen()
    {
        red_screen.SetActive(true);
    }

    public void off_red_screen()
    {
        red_screen.SetActive(false);
    }

    public void invoke_red_screen()
    {
        Invoke("off_red_screen", 0.18f);
    }

    public void show_green_screen()
    {
        green_screen.SetActive(true);
    }

    public void off_green_screen()
    {
        green_screen.SetActive(false);
    }

    public void invoke_green_screen()
    {
        Invoke("off_green_screen", 0.18f);
    }
}
