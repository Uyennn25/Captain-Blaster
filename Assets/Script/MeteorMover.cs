using System;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    public float speed = -2f;
    private Rigidbody2D rb;
    private GameManager gameManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }
   
}
