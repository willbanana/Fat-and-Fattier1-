using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snkk : MonoBehaviour
{

    public float speed;

    [SerializeField]
    protected int health = 3;


    private Transform target;

    
    [SerializeField]
    private GameObject arrowPrefab;
    Vector2 diff;
    public GameObject ArrowPrefab
    {
        get
        {
            return arrowPrefab;
        }

        set
        {
            arrowPrefab = value;
        }
    }

    // Use this for initialization
    void Start()
    {


        //find the target
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }


    



    void Update()
    {
        //move the enemy

        diff = transform.position;

        Vector2 move = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = move;
        diff = diff - move;



        //animation

        
    }


}
