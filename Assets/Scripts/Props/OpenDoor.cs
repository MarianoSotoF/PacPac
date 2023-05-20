using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool opening = false;
    private GameObject pivot;
    private Collider[] col;
    public bool opened = false;

    private void Start() {
        pivot = transform.parent.gameObject;
        col = GetComponents<Collider>();
    }

    private void FixedUpdate() {
        if(opening) {
            pivot.transform.Rotate(0,-3,0);
            Debug.Log(pivot.transform.eulerAngles.y);
            if(pivot.transform.eulerAngles.y < 253){opening = false; col[1].isTrigger = false;}
        }
    }

    public void CloseDoor() {
        opening = true;
        col[1].isTrigger = true;
        opened = true;
    }
}