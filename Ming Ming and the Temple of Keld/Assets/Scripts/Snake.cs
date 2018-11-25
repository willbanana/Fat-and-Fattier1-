using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Snake : MonoBehaviour {

    private int health;

    // Use this for initialization
    void Start () {
        health = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Arrow"))
        {

            health--;

            if (health == 0)
            {
                if(PlayerControler.rau==0)
                    SceneManager.LoadScene(3);
                else SceneManager.LoadScene(4);

                //Destroy(col.gameObject);
                //Destroy(gameObject);

            }
        }
    }
}
