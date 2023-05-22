using System;
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

    public float lanternMax = 7.0f;
    public float lanternMin = 1.5f;
    public float lanternDecrTime = 30.0f;
    public float lanternNLightsToFill = 10.0f;
    private float lanternDecr;
    private float lanternIncr;

    void Start() {
        lanternDecr = (lanternMax - lanternMin) / lanternDecrTime;
        lanternIncr = (lanternMax - lanternMin) / lanternNLightsToFill;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Light l = linterna.GetComponent<Light>();
        l.intensity = Math.Max(lanternMin, l.intensity - lanternDecr * Time.deltaTime);
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
            Light l = linterna.GetComponent<Light>();
            l.intensity = Math.Min(lanternMax, l.intensity + lanternIncr);
        }
    }
}
