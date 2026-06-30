using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target; // Stores the target of this enemy
    [SerializeField] private NavMeshAgent agent; // Stores the NavMeshAgent component attached to this enemy

       private void Awake()
    {
        // Get the NavMeshAgent component attached to this enemy
        agent = GetComponent<NavMeshAgent>();
    }
        
     private void Update()
    {
        // Check if the target to follow
        if (target != null)
        {
            // Follow the target
            agent.SetDestination(target.position);
        // This function is caled when this enemy collides with another object
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Attempt to store the PlayerController component from the collided object
                PlayerController player= collision.gameObject.GetComponent<PlayerController>();

                // Check if the object his enemy collided is the player
                if (player != null) // If this enemy collided with the player   
        {
             // Take Damange
             // Kill Player
             Debug.Log($" {gameObject.name} hit {collision.gameObject.name}");
        }
    }

}