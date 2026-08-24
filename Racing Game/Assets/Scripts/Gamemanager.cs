using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Stores the one (and only) instance of this script
    public static GameManager Instance {get; private set;}
    public static bool isGameOver = false; // Stores whether the game is over or not

    private void Awake()
    {
        // Check our singleton
        if (Instance == null)
        {
            // Assign this instance of the script as THE instance
            Instance = this; 
        }
        else // There is already a GameManager assigned
        {
            // Destroy this extra copy of this script
            Destroy(gameObject);
        }

        isGameOver = false; // Reset the game over state when the game starts
    } 
    public void GameOver()
    {
        Debug.Log("Game Over!"); // Log a message to the console for debugging purpose
        if (isGameOver) return; // If the game is already over, don't do anything
        // Set the game over state to true
        isGameOver = true;

        // Show the Game Over UI
        UIManager.Instance.ShowGameOverUI(true);

       
    }

    public void LoadMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene(0);
    }

    public void LoadCurrentScene()
    {
        // Restarts the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}