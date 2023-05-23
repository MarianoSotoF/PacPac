using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lv0_GlobalScript : MonoBehaviour
{
    //Common params
    public CollisionChecking Player;
    public GameObject[] BreakableWalls;
    private GameObject[] Zone1Lights;
    private int NumLigths;

    //Audio params
    public AudioSource player;
    public AudioClip level;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize total number of lights
        Zone1Lights=GameObject.FindGameObjectsWithTag("Light");
        NumLigths=Zone1Lights.Length;
    }

    //General light update
    public void UpdateGlobal(){
        UpdateZoneLights();
    }

    //Exit on complete level
    public void ExitLevel(){
        player.PlayOneShot(level);
        SceneManager.LoadScene("Level_1");
    }

    //Update light counting
    private void UpdateZoneLights(){
        NumLigths--;
        if(NumLigths==0){
            Destroy(BreakableWalls[0]);
            Player.darkness=0;
        }

    }
}
