using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Orange_Intersection_Box : MonoBehaviour {
    public GameObject monstruo;

    public void OnTriggerEnter(Collider o) {
        if(o.CompareTag("Player")) {
            monstruo.GetComponent<Orange_EnemyMovement>().PlayerInRange = true;
        }
    }

    public void OnTriggerExit(Collider o) {
        if(o.CompareTag("Player")) {
            monstruo.GetComponent<Orange_EnemyMovement>().PlayerInRange = false;
        }
    }
}
