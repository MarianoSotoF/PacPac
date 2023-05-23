using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class HUDLogic : MonoBehaviour
{
    private GameObject linterna;
    private Transform battery;
    private Transform sprint;
    private FirstPersonController speedController;
    public GameObject player;
    private ItemList itemList;

    //Color settings
    public Color staminaUnpunished; 
    public Color staminaPunished; 

    void Start() {
        sprint = transform.GetChild(0).GetChild(1);
        battery = transform.GetChild(1).GetChild(1);

        linterna = player.transform.GetChild(0).GetChild(0).gameObject;
        speedController = player.GetComponent<FirstPersonController>();
        itemList = player.GetComponent<ItemList>();
    }

    //Update gauge
    private void ChangeGauge(Transform target, float prop) {
        target.localScale = new Vector3(prop, 1, 1);
    }

    void Update() {
        //Set battery gauge depending on light battery
        float intensity = (linterna.GetComponent<Light>().intensity - itemList.lanternMin) / (itemList.lanternMax - itemList.lanternMin);
        ChangeGauge(battery, intensity);

        //Set stamina gauge depending on sprint capability
        float sprintSpeed = speedController.Stamina_ / 100f;
        ChangeGauge(sprint, sprintSpeed);
        if(!speedController.penalty) {
            //No punishment
            sprint.gameObject.GetComponent<Image>().color = staminaUnpunished;
        } else {
            //Punishment when stamine depleted
            sprint.gameObject.GetComponent<Image>().color = staminaPunished;
        }
    }
}
