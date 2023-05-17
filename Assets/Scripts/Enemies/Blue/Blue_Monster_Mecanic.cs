using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Monster_Mecanic: EnemyMovement
{
    public GameObject[] monsters;

    // Update is called once per frame
    void FixedUpdate()
    {   
        Movimiento();
    }
    GameObject SeleccionarMonstruo(){
        float distance=Vector3.Distance(transform.position,monsters[0].transform.position);
        GameObject monster= monsters[0];
        for(int i=1;i<monsters.Length;i++){
            GameObject auxmons=monsters[i];
            if(distance<Vector3.Distance(this.transform.position,monsters[i].transform.position))
                monster=monsters[i];

        }
        return monster;
    }
    //Control wandering process on the monster
     void Movimiento(){
        if(HasBeenInSight){
            Debug.Log("SUBCLASE");
            timer+=Time.deltaTime;
            pathfinder.SetDestination(transform.position);
            HasBeenInSight=timer<=8;
        }
        else{
            timer=0;
            if(EsVisible()){
                Debug.Log("TELEPORT");
                GameObject monster= SeleccionarMonstruo();
                monster.transform.position=transform.position;
                pathfinder.SetDestination(transform.position);}
            else{
                //Debug.Log("HACIA UN PUNTO");
                if (!pathfinder.pathPending && pathfinder.remainingDistance < 0.5f){
                        //Debug.Log("HACIA OTRO PUNTO");
                        GotoPoint();
                }
            } 
        }
    }
}
