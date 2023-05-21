using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChecking : MonoBehaviour
{
    public int darkness = 0;
    public GlobalScript global;

    void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Light"){
            darkness++;
            global.UpdateZone1Lights();
            //Debug.Log(darkness);
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Light2"){
             darkness++;
            global.UpdateZone2Lights();
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
        if(other.transform.tag == "Blue_monster"){
            //Debug.Log("Te moristeh");
            other.gameObject.SetActive(false);
        }
        if(other.transform.tag == "B_Monster_Trigger"){
            Debug.Log("Te moristeh");
            global.SummonBlueMonster();
            other.gameObject.SetActive(false);
        }
    }
}
