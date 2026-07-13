using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    [SerializeField] private Transform[] waypoints; // Stores the target of this enemy
    [SerializeField] private NavMeshAgent agent; // Stores the NavMeshAgent component attached to this enemy
    [SerializeField] private int currentWaypoint = 0; // Internal tracker for what waypoint the agent is following

       private void Awake()
    {
        // Get the NavMeshAgent component attached to this enemy
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // Check if the array of waypoints is not empty, then set the first destination
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
        }
    }
        
     private void Update()
    {
        if (waypoints.Length == 0) return; // Do nothing if there are no waypoints left

        // if the agent has reached their current waypoint...
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Set the next waypoint
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = waypoints.Length - 1;
                // Or loop back to 0 if desired.
            }

            agent.SetDestination(waypoints[currentWaypoint].position);
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