using UnityEngine;
using UnityEngine.AI;
using KBCore.Refs;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    private int i;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<GameObject> waypoints = new List<GameObject>();
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
        if (waypoints.Count < 0) return;
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            i = (i + 1) % waypoints.Count;
            destination = waypoints[i].transform.position;
            agent.destination = destination;
        }
    }
}
