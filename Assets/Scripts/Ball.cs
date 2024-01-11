using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float speed = 25f;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(9.8f * speed, 9.8f * speed));
    }

}
