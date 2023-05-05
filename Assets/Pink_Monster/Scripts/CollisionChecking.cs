using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecking : MonoBehaviour
{
    private int darkness = 0;

    void OnCollisionEnter(Collision other){
        if(other.transform.tag == "Light"){
            darkness++;
            Debug.Log("IN"+darkness);
            Destroy(other.gameObject);
        }
        Debug.Log("OUT" + other.gameObject.name);
    }
}
