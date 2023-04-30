using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform Player;
    private UnityEngine.AI.NavMeshAgent pathfinder;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(GetComponent<EnemySeen>().Active){
            pathfinder.SetDestination(Player.position);
        }
        else{pathfinder.SetDestination(transform.position);}
    }
}
