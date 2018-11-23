using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;

    private Transform target;



	// Use this for initialization
	void Start () {
        //find the target
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
        //move the enemy
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

	}
}
