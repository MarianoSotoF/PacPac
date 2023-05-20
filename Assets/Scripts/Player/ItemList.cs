using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class ItemList : MonoBehaviour
{
    public GameObject linterna;
    public Text textoItem; 
    bool OnItem=false;
    public int Keys=0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(linterna.GetComponent<Light>().intensity*0.9995f >= 1.5f){
            linterna.GetComponent<Light>().intensity*=0.9995f;
        }else{
            linterna.GetComponent<Light>().intensity = 1.5f;
        }
    }
    
    // void OnTriggerEnter(Collider other) {
    //     Debug.Log("CHOQUE");
    //     if(Keys>0 && other.gameObject.CompareTag("Door")){
    //         Debug.Log("OPEN DOOR");
    //         Keys--;
    //         Destroy(other.gameObject);
    //     }
    // }

    void OnTriggerStay(Collider other) {
        
        if(other.gameObject.CompareTag("Key")){
            //Debug.Log("Choca con LLAVE");
            textoItem.text="Press 'E' to pick up " + other.gameObject.tag;
            if(Input.GetKeyDown(KeyCode.E)){
            // Debug.Log("ES UNA LLAVE");
                Keys++;
                Destroy(other.gameObject);
                textoItem.text="";
                // Debug.Log("TENGO LA LLAVE");
            }
        }
         if(other.gameObject.CompareTag("Door")){
            textoItem.text="Press 'E' to Open "+other.gameObject.tag;
            if(Keys>0 && Input.GetKeyDown(KeyCode.E)){
            // Debug.Log("OPEN DOOR");
            Keys--;
            other.gameObject.SendMessage("CloseDoor", SendMessageOptions.DontRequireReceiver);
            textoItem.text="";}
            else if(Keys<=0)
            textoItem.text="You don't have any key";
        }
    }
    void OnTriggerExit(Collider other) {
        textoItem.text="";

        if(other.transform.tag == "Light"){
            if(linterna.GetComponent<Light>().intensity*1.2f <= 7){
                linterna.GetComponent<Light>().intensity*=1.2f;
            }else{
                linterna.GetComponent<Light>().intensity = 7;
            }
        }
    }
}
