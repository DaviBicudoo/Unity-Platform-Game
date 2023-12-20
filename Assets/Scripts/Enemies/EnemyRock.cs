using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRock : MonoBehaviour
{
    public float speed;
    public float walkTime; // Time that enemy will walk
    private float timer; // That will complement walkTime

    public float health;
    public float damage = 2f;
    float impulse = 3f;
   
    private Rigidbody2D rig;
    private Animator anime;

    private bool walkRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); // Attach to the editor
        anime = GetComponent<Animator>(); // Attach to the editor
    }

    // Update is called once per frame
    void FixedUpdate() // Using physics
    {
        timer += Time.deltaTime; // Timer += 1 second

        if (timer >= walkTime) // If timer >= walkTimer (set in engine)
        {
            walkRight = !walkRight; // Is time to walk to other side (walkRight = true -> right | walkRight = false -> left)
            timer = 0f; // Timer is reseted to start a new timer
        }
        
        if(walkRight) // If is walking to right
        {
            rig.velocity = Vector2.right * speed; // So walk to right xD
            rig.transform.eulerAngles = new Vector3(0f, 180f, 0f); // And invert the enemy 180º to right
        }
        else // If is walking to left
        {
            rig.velocity = Vector2.left * speed; // So walk to left :D
            rig.transform.eulerAngles = new Vector3(0f, 0f, 0f); // And invert the enemy to 0º and look to left
        }
    }

    public void Damage(float damage)
    {
        health -= damage; // EnemyRock health decreased by damage
        anime.SetTrigger("Hit");

        if(health <= 0f) // Die
        {
            Destroy(gameObject); // Destroy instance
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage, impulse); // If collide with player, so player receives damage
        }
    }
}
