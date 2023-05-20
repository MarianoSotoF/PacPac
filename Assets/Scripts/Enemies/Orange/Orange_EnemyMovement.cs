using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orange_EnemyMovement : MonoBehaviour {
    private bool playerInSight;
    private Vector3 origin;
    private Transform player;
    private NavMeshAgent pathfinder;

    public bool PlayerInSight {
        get { return playerInSight; }
        set { playerInSight = value; }
    }

    void Start() {
        origin = transform.position;
        playerInSight = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if(playerInSight)
            pathfinder.SetDestination(player.position);
        else {
            pathfinder.SetDestination(origin);
        }
    }
}
