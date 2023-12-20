using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float explosionForce; 
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage, explosionForce); // Player get hit kill

            GameController.instance.GameOver(); // So game over :D
        }
    }


}
