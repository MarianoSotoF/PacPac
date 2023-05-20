using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Intersection_Box : MonoBehaviour {
    public GameObject monstruo;

    public void OnTriggerEnter(Collider o) {
        if(o.tag == "Player") {
            Console.WriteLine("hola");
            monstruo.GetComponent<Orange_EnemyMovement>().PlayerInSight = true;
        }
    }

    public void OnTriggerExit(Collider o) {
        if(o.tag == "Player") {
            Console.WriteLine("bye");
            monstruo.GetComponent<Orange_EnemyMovement>().PlayerInSight = false;
        }
    }
}
