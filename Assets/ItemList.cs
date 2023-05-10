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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        linterna.GetComponent<Light>().intensity*=0.999f;
        
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
            textoItem.text="E "+other.gameObject.tag;
            if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("ES UNA LLAVE");
                Keys++;
                Destroy(other.gameObject);
                textoItem.text="";
                Debug.Log("TENGO LA LLAVE");}
        }
         if(other.gameObject.CompareTag("Door")){
            textoItem.text="E Open "+other.gameObject.tag;
            if(Keys>0 && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("OPEN DOOR");
            Keys--;
            Destroy(other.gameObject);
            textoItem.text="";}
            else if(Keys<=0)
            textoItem.text="You dont have any key";
        }
    }
    void OnTriggerExit(Collider other) {
        textoItem.text="";
    }
}
