using UnityEngine;

public class Gameovertrigger : MonoBehaviour
{
   [SerializeField] private GameManager gameManager;
        
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object that collided with this trigger has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the GameOver method from the GameManager
            Debug.Log("died"); 
            GameManager.Instance.GameOver();
        }
    }
}
