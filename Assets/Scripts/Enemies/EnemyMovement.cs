using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    protected Transform Player;
    public UnityEngine.AI.NavMeshAgent pathfinder;
    protected float timer=0;
    protected int destPoint=0;
    protected bool HasBeenInSight=false;
    public Transform[] PathPoints;

    public AudioSource Red_Monster_;
    public AudioClip red;
    public AudioClip horror;

    //Indicates if the player is or isn't visible
    protected bool EsVisible(){
        return HasBeenInSight=Vector3.Distance(Player.position,this.transform.position)<=15;
    }

    //Set the new target point to go to for the monster
    protected void GotoPoint(){
        // Returns if no points have been set up
        if (PathPoints.Length == 0)
            return;
        destPoint=(destPoint+1)%PathPoints.Length;
        // Set the agent to go to the currently selected destination.
        pathfinder.destination = PathPoints[destPoint].position;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GotoPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Wandering();
    }

    //Control wandering process on the monster
    protected void Wandering(){
        if(HasBeenInSight){
            Red_Monster_.PlayOneShot(red);
            Red_Monster_.PlayOneShot(horror);
            //Debug.Log("TE VEO");
            timer+=Time.deltaTime;
            pathfinder.SetDestination(Player.position);
            HasBeenInSight=timer<=5;
        }
        else{
            timer=0;
            if(EsVisible())
                pathfinder.SetDestination(Player.position);
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
