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

    public AudioSource Monster_;
    public AudioClip monster_cry;

    public GameObject global;

    private bool changeMusicStatus = false;

    //Indicates if the player is or isn't visible
    protected bool EsVisible(){
        return HasBeenInSight=Vector3.Distance(Player.position,this.transform.position)<=18.0f;
    }

    //Set the new target point to go to for the monster
    protected void GotoPoint(){
        // Returns if no points have been set up
        if (PathPoints.Length == 0)
            return;


        destPoint=(int)Random.Range(0,PathPoints.Length);
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
            //Debug.Log("TE VEO");
            timer+=Time.deltaTime;
            pathfinder.SetDestination(Player.position);
            HasBeenInSight=timer<=7.5f;
        }
        else{
            timer=0;
            if(EsVisible()){
                Monster_.PlayOneShot(monster_cry);
                if(!changeMusicStatus){global.SendMessage("PlayMusic", true, SendMessageOptions.DontRequireReceiver); changeMusicStatus = true;}
                pathfinder.SetDestination(Player.position);
            }
            else{
                //Debug.Log("HACIA UN PUNTO");
                if(changeMusicStatus){global.SendMessage("PlayMusic", false, SendMessageOptions.DontRequireReceiver); changeMusicStatus = false;}
                if (!pathfinder.pathPending && pathfinder.remainingDistance < 0.5f){
                        //Debug.Log("HACIA OTRO PUNTO");
                        GotoPoint();
                }
            } 
        }
    }
}
