using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orange_EnemyMovement : MonoBehaviour {
    private Vector3 origin;
    private Transform player;
    private NavMeshAgent pathfinder;

    private float timeInsideTrigger;
    private float timeOutsideTrigger;

    private bool playerInRange;
    public bool PlayerInRange {
        get { return playerInRange; }
        set { 
            if(!value) {
                timeOutsideTrigger = timeInsideTrigger;
                pathfinder.ResetPath();
            }
            playerInRange = value; 
        }
    }

    void Start() {
        origin = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerInRange = false;
        timeOutsideTrigger = 0.0f;
        timeInsideTrigger = 3.0f;
    }

    void FixedUpdate()
    {
        if(playerInRange) { // move towards played if inside area
            pathfinder.SetDestination(player.position);
            if(DetectPlayerInSight()) {
                pathfinder.speed = 3.8f;
            } else {
                pathfinder.speed = 1.5f;
            }
        } else if(timeOutsideTrigger > 0.0f) { // wait for a bit once player is out of area
            timeOutsideTrigger -= Time.deltaTime;
        } else { // go back if player is outside area for long enough
            pathfinder.SetDestination(origin);
            pathfinder.speed = 4f;
        }
    }

    private bool DetectPlayerInSight() {
        Vector3 playerPos = player.transform.position;
        Vector3 orangePos = transform.position;
        Vector3 dirRay = (orangePos - playerPos);
        dirRay.Normalize();

        // Vector3 interactionRayEndpoint = dirRay * 1000 + playerPos;
        // Debug.DrawLine(playerPos, interactionRayEndpoint, new Color(0f, 0f, 1f));

        RaycastHit interactionRayhit;
        if(Physics.Raycast(new Ray(playerPos, dirRay), out interactionRayhit, float.PositiveInfinity)) {
            return interactionRayhit.transform.gameObject.CompareTag("Orange_Monster");
        } else {
            return false;
        }
    }
}
