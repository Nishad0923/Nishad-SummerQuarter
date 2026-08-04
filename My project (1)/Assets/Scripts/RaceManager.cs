using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject winUI; // Assign a win screen panel in the Inspector
    public float restartDelay = 5f;

    private bool raceFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object touching the finish line is the player
        if (other.CompareTag("Player") && !raceFinished)
        {
            raceFinished = true;

            Debug.Log("Race Finished!");

            // Show win screen
            if (winUI != null)
            {
                winUI.SetActive(true);
            }

            // Stop time (optional)
            Time.timeScale = 0f;

            // Restart scene after delay (remove if not needed)
            // Invoke("RestartRace", restartDelay);
        }
    }

    void RestartRace()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


