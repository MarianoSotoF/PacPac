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
    protected int destPoint=0;
    protected bool HasBeenInSight=false;
    public Transform[] PathPoints;

    public AudioSource Monster_;
    public AudioClip monster_cry;

    public GameObject global;

    private bool changeMusicStatus = false;

    //Indicates if the player is or isn't visible
    protected bool EsVisible(){
        float interactionRayLength = 30.0f;
        bool playerInFront = false;
        bool playerNear = false;

        playerNear = Vector3.Distance(Player.position,this.transform.position) <= interactionRayLength;

        if(playerNear){
            //Use raycasting from enemy to player to check if there no wall between them, but just if they're close enough
            Vector3 rayDirection = Player.position - transform.position;
            Ray interactionRay = new Ray(transform.position, rayDirection);
            RaycastHit interactionRayHit;
            Vector3 interactionRayEndpoint = rayDirection * interactionRayLength + transform.position;
            Debug.DrawLine(transform.position, interactionRayEndpoint);
            
            //Collision check
            bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);

            if(hitFound){
                GameObject hitGameObject = interactionRayHit.transform.gameObject;

                // Interaction with Pink_monster
                if(hitGameObject.CompareTag("Player")){
                    playerInFront = true;
                }
                else{playerInFront = false;}
            }
        }
        
        HasBeenInSight = playerNear && playerInFront;
        return HasBeenInSight ;
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
            Debug.Log("TE VEO");
            pathfinder.SetDestination(Player.position);
        }
        else{
            if(EsVisible()){
                Monster_.PlayOneShot(monster_cry);
                if(!changeMusicStatus){global.SendMessage("PlayMusic", true, SendMessageOptions.DontRequireReceiver); changeMusicStatus = true;}
                pathfinder.SetDestination(Player.position);
                StartCoroutine(StopAttack());
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

    protected IEnumerator StopAttack(){
        yield return new WaitForSeconds(8.0f);
        HasBeenInSight = false;
    }
}
