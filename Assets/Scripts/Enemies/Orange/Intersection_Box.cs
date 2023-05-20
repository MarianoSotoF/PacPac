using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection_Box : MonoBehaviour {
    public GameObject monstruo;

    private void OnTriggerEnter(Collider o) {
        if(o.tag == "Player") {
            monstruo.GetComponent<Orange_EnemyMovement>().MarcarJugador(true);
        }
    }

    private void OnTriggerExit(Collider o) {
        if(o.tag == "Player") {
            monstruo.GetComponent<Orange_EnemyMovement>().MarcarJugador(false);
        }
    }
}
