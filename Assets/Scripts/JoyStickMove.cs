using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public Joystick movementJoySticks;
    public float playerSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(movementJoySticks.Direction.y!=0)
        {
            rb.velocity=new Vector2(movementJoySticks.Direction.x*playerSpeed,movementJoySticks.Direction.y*playerSpeed);

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
