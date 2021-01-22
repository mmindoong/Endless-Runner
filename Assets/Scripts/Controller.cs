using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{


    private Rigidbody2D player;
    private Animator animator;
    private const float POWER = 15.0f;
    private bool isjump = false;
    private bool isslide = false;
    private int jumpCount = 0;
 

    // Start is called before the first frame update
    private void Start()
    {
    player = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();



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

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag.Equals("Land"))
            {
            isjump = false;
            
            }

    }




}

