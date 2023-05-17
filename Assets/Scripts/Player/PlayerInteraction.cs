using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject darknessChart;
    public Sprite[] darknessChartLevels;
    public Text textoItem; 

    private int MaxLights = 0;
    private int darkness;
    private GameObject breakableWall;

    void Start() {
        MaxLights = GameObject.FindGameObjectsWithTag("Light").Length;
        breakableWall = GameObject.FindGameObjectWithTag("breakableWall");
    }

    // Update is called once per frame
    void Update()
    {
        //Raycasting
        InteractRaycast();
        //Show/ Hide Darkness Chart
        if (Input.GetKeyDown(KeyCode.M)){
            UpdateDarknessChart();
            darknessChart.SetActive(!darknessChart.activeSelf);
        }
    }

    void FixedUpdate() {
        darkness = transform.parent.GetComponent<CollisionChecking>().darkness;
        if(darknessChart.activeSelf){UpdateDarknessChart();}
        if(darkness == MaxLights){
            Destroy(breakableWall);
        }
    }

    void UpdateDarknessChart(){
        int darknessLevel = (int)Mathf.Floor(((float)darkness/MaxLights)*(darknessChartLevels.Length-1));
        darknessChart.transform.GetChild(0).GetComponent<Image>().sprite = darknessChartLevels[darknessLevel];
    }

    void InteractRaycast()
    {
        Vector3 playerPosition = transform.position;
        Vector3 forwardDirection = transform.forward;

        Ray interactionRay = new Ray(playerPosition, forwardDirection);
        RaycastHit interactionRayHit;
        float interactionRayLength = 30.0f;

        Vector3 interactionRayEndpoint = forwardDirection * interactionRayLength + playerPosition;
        Debug.DrawLine(playerPosition, interactionRayEndpoint);

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
        
        if(hitFound){
            GameObject hitGameObject = interactionRayHit.transform.gameObject;

            // Interaction with Pink_monster
            if(hitGameObject.CompareTag("Pink_monster")){
                hitGameObject.SendMessage("BeenSeen", SendMessageOptions.DontRequireReceiver);
            }

            // Change action text to black when looking at a door
            if(hitGameObject.CompareTag("Door")){
                textoItem.color = Color.black;
            }
            
            // Change action text to white by default
            if(!hitGameObject.CompareTag("Door")){
                textoItem.color = Color.white;
            }
        }
    }
}
