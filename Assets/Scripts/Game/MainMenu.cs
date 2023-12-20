using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // Back to menu scene
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1); // Starts game
        if(Input.anyKeyDown) // "Press any key to continue"
        {
            SceneManager.LoadScene(2);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2); // Game
    }

    public void Credits()
    {
        SceneManager.LoadScene(3); // About me 
    }
}
