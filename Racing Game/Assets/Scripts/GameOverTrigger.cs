using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
   [SerializeField] private GameManager gameManager;
        
    void OnCollisionEnter(Collision collision)
    {
        
        
            // Call the GameOver method from the GameManager
            Debug.Log("died"); 
            GameManager.Instance.GameOver();
        
    }
}
