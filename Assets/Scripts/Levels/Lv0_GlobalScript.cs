using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lv0_GlobalScript : MonoBehaviour
{
    public CollisionChecking Player;
    public GameObject[] BreakableWalls;
    GameObject[] Zone1Lights;
    private int NumLigths;

    public AudioSource player;
    public AudioClip level;

    
    // Start is called before the first frame update
    void Start()
    {

        Zone1Lights=GameObject.FindGameObjectsWithTag("Light");
        NumLigths=Zone1Lights.Length;
    }

    public void UpdateGlobal(){
        UpdateZoneLights();
    }

    public void ExitLevel(){

        player.PlayOneShot(level);
        SceneManager.LoadScene("Level_1");
    }

    private void UpdateZoneLights(){
        NumLigths--;
        if(NumLigths==0){
            Destroy(BreakableWalls[0]);
            Player.darkness=0;
        }

    }
}
