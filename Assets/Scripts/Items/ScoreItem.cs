using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    public int scoreValue; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.UpdateScore(scoreValue); // Update score value in canva and in database (through GameController.instance)
            
            Destroy(gameObject); 
        }
    }
}
