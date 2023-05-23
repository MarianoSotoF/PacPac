using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pink_EnemyMovement : EnemyMovement
{
    // Update is called once per frame
    void FixedUpdate()
    {   
        if(GetComponent<EnemySeen>().Active){
            Wandering();
            //Update speed when attacking
            if(HasBeenInSight){GetComponent<NavMeshAgent>().speed = 8.0f;}          //On attack
            else{GetComponent<NavMeshAgent>().speed = 3.5f;}                        //Normal speed
        }
        else{pathfinder.SetDestination(transform.position);}
    }
}
