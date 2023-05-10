using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink_EnemyMovement : EnemyMovement
{
    // Update is called once per frame
    void FixedUpdate()
    {   
        if(GetComponent<EnemySeen>().Active){
            Wandering();
        }
        else{pathfinder.SetDestination(transform.position);}
    }
}
