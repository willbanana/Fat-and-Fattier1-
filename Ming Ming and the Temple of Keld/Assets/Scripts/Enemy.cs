using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private int health;

    public static int nr = 0;
   
    // Use this for initialization
    void Start () {
        health = 3;
        
    }
    
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Arrow"))
        {
            health--;
           
            if (health == 0)
            {
                nr = 1;
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
