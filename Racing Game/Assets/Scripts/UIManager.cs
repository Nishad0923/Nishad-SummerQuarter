using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}
    
    [ SerializeField] private TextMeshProUGUI timertext; // 
    [SerializeField] private GameObject gameOverUI; // Stores the Game Over UI object


    // Awake() called when this gameobject is enabled in the scene 
    private void Awake()
    {
    // If there is no other instance of thi script in the scene...
        if (Instance== null)
        {
            Instance = this;
        }
        else
        {
            // Destroy this extra copy of this script
            Destroy(gameObject);
        }

        ShowGameOverUI(false); // Hide the Game Over UI at the start of the game
    }
    public void UpdateTimer(float time)
    {
        // Update the timer text object with the given time
        timertext.text = "Time: " + time.ToString("F1");
    }

    public void ShowGameOverUI(bool flag)
    {
        // Show the Game Over UI
        gameOverUI.SetActive(flag);
    }

}
