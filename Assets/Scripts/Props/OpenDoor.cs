using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool opening = false;
    private GameObject pivot;
    private Collider[] col;
    public bool opened = false;
    private float currentAngle = 0.0f;

    private void Start() {
        pivot = transform.parent.gameObject;
        col = GetComponents<Collider>();
    }

    private void FixedUpdate() {
        //Start opening animation
        if(opening) {
            pivot.transform.Rotate(0,-3,0);
            currentAngle += 3;
            
            Debug.Log(pivot.transform.eulerAngles.y);
            Debug.Log(currentAngle);
            if(currentAngle >= 107){opening = false; col[1].isTrigger = false;}
        }
    }

    public void Open() {
        //Forbid opening again
        opening = true;
        col[1].isTrigger = true;
        opened = true;
    }
}