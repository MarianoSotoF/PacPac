using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orange_EnemyMovement : MonoBehaviour {
    private bool playerInSight;
    private Vector3 origin;
    private Transform player;
    private NavMeshAgent pathfinder;

    void Start() {
        origin = transform.position;
        playerInSight = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void MarcarJugador(bool cond) {
        playerInSight = cond;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Wandering();
    }

    //Control wandering process on the monster
    protected void Wandering(){
        if(playerInSight)
            pathfinder.SetDestination(player.position);
        else {
            pathfinder.SetDestination(origin);
        }
    }
}
