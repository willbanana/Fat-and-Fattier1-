using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed, ok=0;

    private bool facingRight;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator myAnimator;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void ResetPressed()
    {
        myAnimator.SetBool("leftPressed", false);
        myAnimator.SetBool("upPressed", false);
        myAnimator.SetBool("downPressed", false);
        myAnimator.SetBool("rightPressed", false);
        ok = 0;
    }

    void Update()
    {
        //left and right movement:

        if (Input.GetKey(KeyCode.A))
        {
            ResetPressed();
            myAnimator.SetBool("leftPressed", true);
            ok = 1;
            if (ok == 1)
            {
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y);
                ok = 0;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            ResetPressed();
            myAnimator.SetBool("rightPressed", true);
            ok = 2;
            if (ok == 2)
            {
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y);
                ok = 0;
            }
        }

        //up and down movement:

        if (Input.GetKey(KeyCode.W))
        {
            ResetPressed();
            myAnimator.SetBool("upPressed", true);
            ok = 3;
            if (ok == 3)
            {
                rb.AddForce(transform.up * movementSpeed);
                ok = 0;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            ResetPressed();
            myAnimator.SetBool("downPressed", true);
            ok = 4;
            {
                rb.AddForce(transform.up * -movementSpeed);
                ok = 0;
            }
            
        }
    }
        
        
    }
