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

    void Start() {
        sprint = transform.GetChild(0).GetChild(1);
        battery = transform.GetChild(1).GetChild(1);

        linterna = player.transform.GetChild(0).GetChild(0).gameObject;
        speedController = player.GetComponent<FirstPersonController>();
    }

    private void ChangeGauge(Transform target, float prop) {
        target.localScale = new Vector3(prop, 1, 1);
    }

    void Update() {
        float intensity = (linterna.GetComponent<Light>().intensity - 1.5f) / 5.5f;
        ChangeGauge(battery, intensity);

        float sprintSpeed = (linterna.GetComponent<Light>().intensity - 1.5f) / 5.5f;
        ChangeGauge(sprint, intensity);
    }
}
