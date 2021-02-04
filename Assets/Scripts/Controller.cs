using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Scrollbar HealthBar;

    public Text ScoreText;
    public Text DieText;

    private Rigidbody2D player;
    private Animator animator;
    private const float POWER = 15.0f;
    private bool isjump = false;
    private bool isslide = false;
    private int jumpCount = 0;
    private int Score = 0;
    private float health = 100f;


    // Start is called before the first frame update
    private void Start()
    {
    player = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
        ScoreRenew();
        LifeRenew();

        StartCoroutine("NextPage");


    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.UpArrow) && !isjump)
        {
            player.velocity = (Vector2.up * POWER);
            animator.SetInteger("move", jumpCount);
            isjump = true;
        }
        
    }

    private void Update()
    {
        health -= 0.02f;
        LifeRenew();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("move", false);
            animator.SetBool("slide", true);
            isslide = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("slide", false);
            animator.SetBool("move", true);
            isslide = false;

        }
        if (0 >= HealthBar.size)
        {
            animator.SetBool("Die", true);
            GameManager.instance.gameOver = true;
        }

        if (transform.position.y < -10)
        {
            GameManager.instance.gameOver = true;
        }

        if (GameManager.instance.gameOver)
        {
            DieText.enabled = true;
            LifeRenew();
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag.Equals("Land"))
            {
            isjump = false;
            
            }

    }

    void LifeRenew()
    {
        HealthBar.size = health / 100f;
    }

    void ScoreRenew()
    {
        ScoreText.text = "Score : " + Score.ToString();
    }

    IEnumerator NextPage()
    {
        while (true)
        {
            yield return new WaitForSeconds(15.0f);
            GameManager.instance.stage++;
        }
    }




}

