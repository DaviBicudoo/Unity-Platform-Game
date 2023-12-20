using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text healthText;
    public Text scoreText;

    public GameObject gameOverObject;
    public GameObject pauseGameObject;
    public GameObject finalGameObject;

    public AudioSource audioSource; // Play music

    public int score; 
    public int totalScore;

    public static GameController instance; // static type make this variable acessible in any script (like an method of GameController?)

    private bool isPaused = false;

    // Awake() is initialized before every start(), avoiding conflicts between methods
    private void Awake() // Awake() initialize variables and instances before Start() avoiding conflict between methods
    {
        instance = this; 
    }

    private void Start() 
    {
        totalScore = PlayerPrefs.GetInt("Score"); // Total score receive an int in database with id="Score" (is it?)
    }

    private void Update()
    {
        PauseGame(); // The game is paused (through canva)
    }

    public void UpdateLife(float value)
    {
        healthText.text = "x " + value.ToString(); // Player life
    }

    public void UpdateScore(int value)
    {
        score += value; // Score increase by 1 for coin collected 
        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("Score", score + totalScore); // PlayerPrefs is a class that creates an archive and then stores some values in it. It's like a database. In this case, it will store score value in this database.
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // If press ESC
        {
            isPaused = !isPaused; // For every click in ESC, isPaused receive the contrary value 
            pauseGameObject.SetActive(isPaused); // isPaused (through canva)
        }

        if(isPaused)
        {
            Time.timeScale = 0f; // Freeze game
        }
        else
        {
            Time.timeScale = 1f; // "Defrost" game
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // Load menu scene
    }

    public void GameOver()
    {
        gameOverObject.SetActive(true); // Shows GameOver scene (through canva)
        Time.timeScale = 0f; // Freeze game
    }

    public void RestartGame() // When die
    {
        SceneManager.LoadScene(1);
    }

    public void FinalGame() // If reach the final game
    {
        finalGameObject.SetActive(true); // The final screen is showed (through canva again xD)
        Time.timeScale = 0f; // Freeze game
    }
}
