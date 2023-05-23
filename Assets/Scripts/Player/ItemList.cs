using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class ItemList : MonoBehaviour
{
    //Common params
    public GameObject linterna;
    public Text textoItem;
    public int Keys=0;

    //Audio params
    public AudioSource player;
    public AudioClip key_;
    public AudioClip lights_;
    public AudioClip door_;
    public AudioClip error;

    //Light params
    public float lanternMax = 7.0f;
    public float lanternMin = 1.5f;
    public float lanternDecrTime = 30.0f;
    public float lanternNLightsToFill = 10.0f;
    private float lanternDecr;
    private float lanternIncr;

    void Start() {
        //Initialize light params
        lanternDecr = (lanternMax - lanternMin) / lanternDecrTime;
        lanternIncr = (lanternMax - lanternMin) / lanternNLightsToFill;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Update light status
        Light l = linterna.GetComponent<Light>();
        l.intensity = Math.Max(lanternMin, l.intensity - lanternDecr * Time.deltaTime);
    }

    void OnTriggerStay(Collider other) {
        //Check if in range to pick up a key
        if(other.gameObject.CompareTag("Key")){
            //Debug.Log("Choca con LLAVE");
            textoItem.text="Press 'E' to pick up " + other.gameObject.tag;
            if(Input.GetKeyDown(KeyCode.E)){
            // Debug.Log("ES UNA LLAVE");
                player.PlayOneShot(key_);
                Keys++;                         //Key picked
                Destroy(other.gameObject);
                textoItem.text="";
                // Debug.Log("TENGO LA LLAVE");
            }
        }
        //Check if in range to open a door
        if(other.gameObject.CompareTag("Door") && other.gameObject.transform.GetComponent<OpenDoor>().opened == false){
            textoItem.text="Press 'E' to Open "+other.gameObject.tag;
            if(Keys>0 && Input.GetKeyDown(KeyCode.E)){
            // Debug.Log("OPEN DOOR");
            player.PlayOneShot(door_);
            Keys--;
            other.gameObject.SendMessage("Open", SendMessageOptions.DontRequireReceiver);   //Tell the door to open
            textoItem.text="";}
            else if(Keys<=0){                               //Not enought keys
                textoItem.text="You don't have any key";
                player.PlayOneShot(error);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        textoItem.text="";

        //Check if you broke the light
        if(other.transform.tag == "Light"){
            player.PlayOneShot(lights_);
            Light l = linterna.GetComponent<Light>();
            l.intensity = Math.Min(lanternMax, l.intensity + lanternIncr); //Update light count
        }
    }
}
