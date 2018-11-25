using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed;

    public static int  rau = 0;
    private Rigidbody2D rb;

    private Vector2 moveVelocity;

    public Animator myAnimator;

    [SerializeField]
    private GameObject arrowPrefab;
    private string leftPressed;

    public double DelayBetweenThrows = 0.7;

    float lastThrowDate;

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

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        lastThrowDate = Time.time;
    }

    
     
    //reset all the values of the animations
    void ResetPressed()
    {
        myAnimator.SetBool("leftPressed", false);
        myAnimator.SetBool("upPressed", false);
        myAnimator.SetBool("downPressed", false);
        myAnimator.SetBool("rightPressed", false);
        
    }

    void Update()
    {
        if (Enemy.nr == 1)
            rau = 1;
        //movement:
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

        if (moveHorizontal > 0)
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



        //setting animations for moving directions

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if ((Time.time - lastThrowDate > DelayBetweenThrows))
            {
                lastThrowDate = Time.time;
                if (myAnimator.GetBool("leftPressed"))
                {
                    GameObject tmp = (GameObject)Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    tmp.GetComponent<Arrow>().Initialize(Vector2.left);
                }

                if (myAnimator.GetBool("rightPressed"))
                {
                    GameObject tmp = (GameObject)Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -180)));
                    tmp.GetComponent<Arrow>().Initialize(Vector2.right);
                }

                if (myAnimator.GetBool("downPressed"))
                {
                    GameObject tmp = (GameObject)Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                    tmp.GetComponent<Arrow>().Initialize(Vector2.down);
                }

                if (myAnimator.GetBool("upPressed"))
                {
                    GameObject tmp = (GameObject)Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                    tmp.GetComponent<Arrow>().Initialize(Vector2.up);
                }
            }
        }
    }

    //movement:
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }

    
    
}
