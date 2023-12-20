using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    public float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>(); 

            healthValue = 10 - player.health; // health value receives max player life (10) less player health (making the player get full life when use item)

            player.IncreaseLife(healthValue); // Full life

            Destroy(gameObject); // Destroy item
        }
    }
}
