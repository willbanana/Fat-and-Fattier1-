﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    { 
            //Movement:
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
        
    }

    void FixedUpdate()
    {   //Movement:
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);


    }
}