using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private float timer=0;
    private int destPoint=0;
    private bool HasBeenInSight=false;
    private Transform Player;
    private UnityEngine.AI.NavMeshAgent pathfinder;
    public Transform[] PathPoints;

    private bool EsVisible(){
        return HasBeenInSight=Vector3.Distance(Player.position,this.transform.position)<=15;

    }
     void GotoPoint() {
            // Returns if no points have been set up
            if (PathPoints.Length == 0)
                return;
            destPoint=(destPoint+1)%PathPoints.Length;
            // Set the agent to go to the currently selected destination.
            pathfinder.destination = PathPoints[destPoint].position;
            
        }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GotoPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(HasBeenInSight){
            timer+=Time.deltaTime;
            pathfinder.SetDestination(Player.position);
            HasBeenInSight=timer<=5;

        }
        else{
        timer=0;
        if(EsVisible())
            pathfinder.SetDestination(Player.position);
        else{
            Debug.Log("HACIA UN PUNTO");
            if (!pathfinder.pathPending && pathfinder.remainingDistance < 0.5f){
                    Debug.Log("HACIA OTRO PUNTO");
                    GotoPoint();}}
        
            
        }
        
        
        
        }
    }
