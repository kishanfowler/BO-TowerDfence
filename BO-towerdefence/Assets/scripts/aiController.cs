using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        patroling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void patroling()
    {
        agent.SetDestination(waypoints[waypointIndex].position);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            nextWaypoint();
            Move(6);
        }
    }
    private void Move(float speed)
    {
        agent.speed = speed;
    }
    void nextWaypoint()
    {
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[waypointIndex].position);
    }
}
