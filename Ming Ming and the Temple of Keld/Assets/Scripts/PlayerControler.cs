using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed;

    //private bool facingRight;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator myAnimator;


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
        
    }
    void Update()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;
         moveHorizontal = Input.GetAxis("Horizontal");
         moveVertical = Input.GetAxis("Vertical");

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * movementSpeed;

        if (moveHorizontal < 0)
        {
            ResetPressed();
            myAnimator.SetBool("leftPressed", true);
        }
        if (moveHorizontal>  0)
        {
            ResetPressed();
            myAnimator.SetBool("rightPressed", true);
        }

        if (moveVertical < 0)
        {
            ResetPressed();
            myAnimator.SetBool("downPressed", true);
        }

        if (moveVertical > 0)
        {
            ResetPressed();
            myAnimator.SetBool("upPressed", true);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
    

}
