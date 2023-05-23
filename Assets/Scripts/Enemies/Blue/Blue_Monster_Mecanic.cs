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
    protected int destPoint=0;
    protected bool HasBeenInSight=false;
    public Transform[] PathPoints;

    public AudioSource Blue_Monster;
    public AudioClip blue;

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
            pathfinder.SetDestination(transform.position);
        }
        else{
            if(EsVisible()){
                GameObject monster= SeleccionarMonstruo();

                Blue_Monster.PlayOneShot(blue);
                if(!changeMusicStatus){global.SendMessage("PlayMusic", true, SendMessageOptions.DontRequireReceiver); changeMusicStatus = true;}
                changeMusicStatus = true;
                monster.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
                monster.transform.position=this.transform.position;
                monster.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=true;
                pathfinder.SetDestination(transform.position);
                StartCoroutine(StopAttack());
            }else{
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
        yield return new WaitForSeconds(4.0f);
        HasBeenInSight = false;
    }
}
