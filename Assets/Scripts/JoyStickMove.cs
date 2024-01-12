using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public Joystick movementJoySticks;
    public float playerSpeed=5f;
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
    private void Reset()
    {
        playerSpeed = 5f;
        GameObject gameObject = GameObject.Find("Floating Joystick");
        movementJoySticks = gameObject.GetComponent<FloatingJoystick>();
    }
    public void Ace()
    {
        playerSpeed = 10f;
    }
}
