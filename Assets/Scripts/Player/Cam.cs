using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform player;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Get the position of player
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.position.x >= 0 && player.position.x <= 27) // Came only moves in axis X in [0, 27] positions, that avoids the player see "limbo" (no background)
        {
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z); // It makes the camera change only on X axis (only following the player)
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime); // Lerp changes position from Initial position (transform.position) to new position (following, X player position), with an smooth camera effect, making an weak delay!
        }
    }
}
