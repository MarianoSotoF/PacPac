using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnemySeen : MonoBehaviour
{
    public bool Active = true;

    public void BeenSeen()
    {
        //Debug.Log("Seen");
        Active = false;
        StartCoroutine(StartMoving());
    }

    //Restart movement
    IEnumerator StartMoving(){
        yield return new WaitForSeconds(1.5f);
        Active = true;
    }
}