using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChecking : MonoBehaviour
{
    private int darkness = 0;
    public GameObject DeathScreen;

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
            StartCoroutine(showDeathScreen());
        }
    }

    IEnumerator showDeathScreen(){
        yield return new WaitForSeconds(3.0f);
        DeathScreen.SetActive(true);
    }
}
