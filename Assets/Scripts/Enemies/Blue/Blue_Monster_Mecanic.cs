using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Blue_Monster_Mecanic: MonoBehaviour
{
    private GameObject Pink_monster;
    private GameObject Red_monster;
    protected Transform Player;
    protected UnityEngine.AI.NavMeshAgent pathfinder;
    protected float timer=0;
    protected int destPoint=0;
    protected bool HasBeenInSight=false;
    public Transform[] PathPoints;

    public AudioSource Blue_Monster;
    public AudioClip blue;
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
        Debug.Log(GameObject.FindGameObjectWithTag("Pink_monster"));
        Pink_monster=GameObject.FindGameObjectWithTag("Pink_monster");
        Red_monster=GameObject.FindGameObjectWithTag("Red_monster");
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GotoPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Movimiento();
    }
    GameObject SeleccionarMonstruo(){
        if(Vector3.Distance(Pink_monster.transform.position,transform.position)>Vector3.Distance(Red_monster.transform.position,transform.position)) return Pink_monster;
        else return Red_monster;
    }
    //Control wandering process on the monster
     void Movimiento(){
        if(HasBeenInSight){
            Blue_Monster.PlayOneShot(blue);
            Blue_Monster.PlayOneShot(horror);
            timer+=Time.deltaTime;
            pathfinder.SetDestination(transform.position);
            HasBeenInSight=timer<=8;
        }
        else{
            timer=0;
            if(EsVisible()){
                GameObject monster= SeleccionarMonstruo();
                monster.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
                monster.transform.position=this.transform.position;
                monster.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=true;
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
