using UnityEngine;
using UnityEngine.AI;
using KBCore.Refs;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public enum NPCStates{ Patrol, Chase } //NPC Finite State Machine

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    private int i;
    [SerializeField, Self] private NavMeshAgent agent;
    [SerializeField] private List<GameObject> waypoints = new List<GameObject>();
    [SerializeField] private NPCStates currentState = NPCStates.Patrol;
    [SerializeField] private Transform player;
    private Vector3 destination;
    void OnValidate(){this.ValidateRefs();}
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
        if (waypoints.Count < 0) return;
        agent.destination =
        destination = waypoints[i].transform.position;
    }
    void Update()
    {
        switch (currentState)
        {
            case NPCStates.Patrol:
                if (waypoints.Count < 0) return;
                if (Vector3.Distance(transform.position, destination) < 3f)
                {
                    i = (i + 1) % waypoints.Count;
                    destination = waypoints[i].transform.position;
                    agent.destination = destination;
                }
                break;
            case NPCStates.Chase:
                agent.destination = player.position;
                break;
            default:
                break;
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = NPCStates.Chase;
            player = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = NPCStates.Patrol;
            agent.destination = destination;
        }
    }
}