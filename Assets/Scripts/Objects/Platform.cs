using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed;

    private float timer;
    public float moveTime;

    private bool isRight;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() // Physics
    {
        Movement();
    }

    public void Movement()
    {
        timer += Time.deltaTime; // Timer is increasing

        if(timer >= moveTime) // If moved enough
        {
            isRight = !isRight; // Change direction
            timer = 0f; // Reset move time
        }

        if (isRight)
        {
            rig.velocity = Vector2.right * speed; 
        }
        else
        {
            rig.velocity = Vector2.left * speed;
        }
    }
}
