/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private int _currentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[_currentWaypointIndex].position);
        }
    }
}
