using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float health;

    public int score;

    public GameObject arrow;
    public Transform firePoint; // Where the fire will be spawned

    private bool isJumping; 
    private bool doubleJump;
    private bool isFire;

    private Rigidbody2D rig; // Used to manipulate physics
    private Animator anime; // Used to animate the character    

    public float movement;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        GameController.instance.UpdateLife(health);
    }

    // Update is called once per frame <-- See?
    void Update() // Can be called at any time
    {
        Jump(); // Jump
        BowFire(); // Fire an arrow
    }

    void FixedUpdate() // Better when using physics
    {
        Move(); // Moving character
    }

    void Move()
    {
        //adiciona velocidade ao corpo do personagem no eixo x e y
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        // Set movement variable to horizontal axis (that makes the keyboard input and the player moves in axis X)
        movement = Input.GetAxis("Horizontal");

        // Moving right
        if (movement > 0)
        {
            if (!isJumping)
            {
                anime.SetInteger("Transition", 2);
            }

            transform.eulerAngles = new Vector3(0, 0, 0); // Player "looking" at right
        }

        // Moving left
        if (movement < 0)
        {
            if (!isJumping)
            {
                anime.SetInteger("Transition", 2);
            }

            transform.eulerAngles = new Vector3(0, 180, 0); // Player "looking" at left
        }

        if (movement == 0 && !isJumping && !isFire)
        {
            anime.SetInteger("Transition", 0); // Player stopped 
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anime.SetInteger("Transition", 1); // Jump animation
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Vertical force
                doubleJump = true; // Can jump again
                isJumping = true; // Is in air
            }
            else
            {
                if (doubleJump) 
                {
                    anime.SetInteger("Transition", 1); // Jump animation
                    rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse); // More vertical force (based on jumpForce value in moment)
                    doubleJump = false; // Can't jump again
                }
            }
        }
    }

    void BowFire()
    {
        StartCoroutine("Fire"); // The BowFire() method use's Fire() coroutine
    }

    IEnumerator Fire() // A coroutine can execute multiples works "between returns"
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFire = true; // Is firingasdfasdfasdfasdfasdfasdflaks djflkasdjf laksdfj lasdfh kajs

            anime.SetInteger("Transition", 3);

            GameObject Arrow = Instantiate(arrow, firePoint.position, firePoint.rotation); // Create an instance of prefab arrow in firePoint position and rotation

            if (transform.rotation.y == 0)
            {
                Arrow.GetComponent<Arrow>().isRight = true; // Arrow going to right -->
            }

            if (transform.rotation.y == 180)
            {
                Arrow.GetComponent<Arrow>().isRight = false; // Arrow going to left <--
            }
            // Arrow is a GameObject that inherits from Arrow.cs class, and use the method isRight to verify the player rotation, and so makes the arrow go through the same direction

            yield return new WaitForSeconds(0.2f); // Wait 0.2 seconds to start other animation

            isFire = false; 

            anime.SetInteger("Transition", 0);
        }
    }

    public void Damage(float damage, float impulse)
    {
        health -= damage; // Player's life decrease
        GameController.instance.UpdateLife(health); // Update the life value in canva through GameController
        anime.SetTrigger("Hit");

        if (transform.rotation.y == 0)
        {
            transform.position -= new Vector3(impulse, 0, 0); // Go to left?
        }

        if (transform.rotation.y == 180)
        {
            transform.position += new Vector3(impulse, 0, 0); // Go to right?
        }

        if (health <= 0)
        {
            GameController.instance.GameOver();
        }
    }

    public void IncreaseLife(float value) // Gain life
    {
        health += value;
        GameController.instance.UpdateLife(health);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // If player collide with layer 8 (ground)
        {
            isJumping = false; // So he ins't jumping
        }

        if(collision.gameObject.layer == 9) // if fall in void
        {
            GameController.instance.GameOver(); // He dies =/
        }
    }
}
