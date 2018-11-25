using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    private int health ;

	// Use this for initialization
	void Start () {
        health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {

            health--;

            if (health == 0)
            {
                //Destroy(col.gameObject);
                SceneManager.LoadScene(5);
                //Destroy(gameObject);
            }
        }
    }
}
