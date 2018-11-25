using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollow : MonoBehaviour
{

    public float speed;

    [SerializeField]
    protected int health = 3;


    private Transform target;

    public Animator enemyAnimator;
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
    void Start() {


        //find the target
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyAnimator = GetComponent<Animator>();
    }


    //reset all the values of the animations
    void ResetPressed()
    {
        enemyAnimator.SetBool("leftPressedE", false);
        enemyAnimator.SetBool("upPressedE", false);
        enemyAnimator.SetBool("downPressedE", false);
        enemyAnimator.SetBool("rightPressedE", false);

    }



    void Update()
    {
        //move the enemy

        diff = transform.position;

        Vector2 move = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = move;
        diff = diff - move;



        //animation



        if (diff.x > 0)
        {

            ResetPressed();
            enemyAnimator.SetBool("leftPressedE", true);

        }

        if (diff.x < 0)
        {

            ResetPressed();
            enemyAnimator.SetBool("rightPressedE", true);

        }
    }
    

}
