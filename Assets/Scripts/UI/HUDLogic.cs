using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class HUDLogic : MonoBehaviour
{
    private Transform battery;
    private Transform sprint;
    public GameObject player;
    private GameObject linterna;
    private FirstPersonController speedController;
    private ItemList itemList;

    public Color staminaUnpunished; 
    public Color staminaPunished; 

    void Start() {
        sprint = transform.GetChild(0).GetChild(1);
        battery = transform.GetChild(1).GetChild(1);

        linterna = player.transform.GetChild(0).GetChild(0).gameObject;
        speedController = player.GetComponent<FirstPersonController>();
        itemList = player.GetComponent<ItemList>();
    }

    private void ChangeGauge(Transform target, float prop) {
        target.localScale = new Vector3(prop, 1, 1);
    }

    void Update() {
        float intensity = (linterna.GetComponent<Light>().intensity - itemList.lanternMin) / (itemList.lanternMax - itemList.lanternMin);
        ChangeGauge(battery, intensity);

        float sprintSpeed = speedController.Stamina_ / 100f;
        ChangeGauge(sprint, sprintSpeed);
        if(!speedController.penalty) {
            sprint.gameObject.GetComponent<Image>().color = staminaUnpunished;
        } else {
            sprint.gameObject.GetComponent<Image>().color = staminaPunished;
        }
    }
}
