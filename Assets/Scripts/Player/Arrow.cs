using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rig; 
    public float speed;

    public float damage;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate() // Better when using Physics (Rigidbody2D)
    {
        if (isRight) // If isRight == true (in Player.cs)
        {
            rig.velocity = Vector2.right * speed; // So the arrow is going to the right
        }
        else // If isRight == false (in Player.cs)
        {
            rig.velocity = Vector2.left * speed; // So the arrow is going to the left
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyRock>().Damage(damage); // Use method Damage() from EnemyRock.cs
            Destroy(gameObject); // Arrow is destroyed
        }
    }
}
