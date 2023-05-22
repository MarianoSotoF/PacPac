using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnemySeen : MonoBehaviour
{
    public bool Active = true;

    public AudioSource Pink_monster;
    public AudioClip pink;
    public AudioClip horror;


    public void BeenSeen()
    {
        Pink_monster.PlayOneShot(horror);
        Pink_monster.PlayOneShot(pink);
        //Debug.Log("Seen");
        Active = false;
        StartCoroutine(StartMoving());
    }

    //Restart movement
    IEnumerator StartMoving(){
        yield return new WaitForSeconds(3);
        Active = true;
    }
}