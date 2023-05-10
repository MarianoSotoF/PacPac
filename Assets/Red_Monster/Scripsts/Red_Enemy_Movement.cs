using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Red_Enemy_Movement : MonoBehaviour
{

    Transform Player;
    private UnityEngine.AI.NavMeshAgent pathfinder;
    

    void Start()
    {
     
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
      
    }

    void Update()
    {
      
        pathfinder.SetDestination(Player.position);
    }

}

/*
 * 
 *  //Verificar si hay una colisión en el camino hacia el jugador
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, direction, out hitInfo, 3f))
        {
            // Si hay una colisión, ajustar la dirección del movimiento
            direction = Vector3.Reflect(direction, hitInfo.normal);
        }
*/