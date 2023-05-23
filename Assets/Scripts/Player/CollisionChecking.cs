using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChecking : MonoBehaviour
{
    public int darkness = 0;
    public GameObject global;

    void OnTriggerExit(Collider other) {
        //Check if just exited a light
        global.SendMessage("UpdateGlobal", SendMessageOptions.DontRequireReceiver);
        if(other.transform.tag == "Light"){
            darkness++;
            //Debug.Log(darkness);
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Light2"){
            darkness++;
            //Debug.Log(darkness);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        //Check if cross the goal
        if(other.transform.tag == "Exit") {
            global.SendMessage("ExitLevel", SendMessageOptions.DontRequireReceiver);
        }
        //Check if had collide with an enemy
        if(other.transform.tag == "Pink_monster" ||
           other.transform.tag == "Red_monster" ||
           other.transform.tag == "Blue_monster" ||
           other.transform.tag == "Orange_monster"){
            //Debug.Log("Te moristeh");

            //Desabilitate player
            other.gameObject.SetActive(false);
            global.SendMessage("PauseMusic", SendMessageOptions.DontRequireReceiver);
            transform.GetChild(0).GetComponent<Camera>().gameObject.SetActive(false);
            transform.position += new Vector3(0, -100, 0);
            global.SendMessage("CallScreamer", other.transform.tag, SendMessageOptions.DontRequireReceiver);        //Tell global controller to show the screamer
        }

        //Check if trigger blue monster spawn
        if(other.transform.tag == "B_Monster_Trigger"){
            //Debug.Log("Te moristeh");
            global.SendMessage("SummonBlueMonster", SendMessageOptions.DontRequireReceiver);
            other.gameObject.SetActive(false);
        }
    }
}
