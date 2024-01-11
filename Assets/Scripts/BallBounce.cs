using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform gameManager;
    //public GameObject ball;
    Vector3 lastVelocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").transform;
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
        CheckVelocity();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed=lastVelocity.magnitude*1.025f;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
    private void CheckVelocity()
    {
        if(rb.velocity.x >15f || rb.velocity.x<-15f )
        {
            rb.velocity = new Vector2(5f,5f);
        }
        if (rb.velocity.y > 15f || rb.velocity.y < -15f)
        {
            rb.velocity = new Vector2(5f, 5f);
        }
        //if (rb.velocity.y <1f && rb.velocity.y> -1f || rb.velocity.x < 1f && rb.velocity.x > -1f)
        //{
        //    GameObject gameObj=Instantiate(gameObject, Vector3.zero, Quaternion.identity);
        //    gameObj.name = "ball";
        //    gameObj.transform.parent = gameManager.transform;
        //    Destroy(gameObject);
            
        //}

    }    
}
