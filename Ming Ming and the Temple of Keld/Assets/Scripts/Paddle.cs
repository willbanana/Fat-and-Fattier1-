using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private void Start()
    {
        
    }
    [SerializeField] float screenWidthInUnits = 16f , min=1, max=15;
    void Update()
    {
        

    float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

    Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x=Mathf.Clamp(mousePosInUnits, min, max);
    transform.position = paddlePos ;
    }


}
