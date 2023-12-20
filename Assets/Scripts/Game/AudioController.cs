using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceBackgroudMusic; // The MP3 file

    void Start()
    {
        audioSourceBackgroudMusic.loop = true; // Is in loop (ever playing)
        audioSourceBackgroudMusic.Play(); // Starts to play music
    }
}
