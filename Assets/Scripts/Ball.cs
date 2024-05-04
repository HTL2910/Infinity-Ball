using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    protected int randomIndex;
    private float speed = 25f;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        randomIndex = Random.Range(0, 4);
        switch (randomIndex)
        {
            case 0:
                rb.AddForce(new Vector2(9.8f * speed, 9.8f * speed)); // Đi theo góc 45 độ (điều này tương đương với cả hai thành phần x và y cùng được tăng lên)
                break;
            case 1:
                rb.AddForce(new Vector2(9.8f * speed, -9.8f * speed)); // Đi theo góc 135 độ (tăng thành phần x, giảm thành phần y)
                break;
            case 2:
                rb.AddForce(new Vector2(-9.8f * speed, -9.8f * speed)); // Đi theo góc 225 độ (giảm cả hai thành phần x và y)
                break;
            case 3:
                rb.AddForce(new Vector2(-9.8f * speed, 9.8f * speed)); // Đi theo góc 315 độ (giảm thành phần x, tăng thành phần y)
                break;
        }

    }

}
