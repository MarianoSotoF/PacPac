using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChecking : MonoBehaviour
{
    public int darkness = 0;

    void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Light"){
            darkness++;
            //Debug.Log(darkness);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.tag == "Pink_monster"){
            //Debug.Log("Te moristeh");
            other.gameObject.SetActive(false);
        }
        if(other.transform.tag == "Red_monster"){
            //Debug.Log("Te moristeh");
            other.gameObject.SetActive(false);
        }
    }
}
