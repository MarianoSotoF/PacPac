using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lv1_GlobalScript : MonoBehaviour
{
    //Common
    public CollisionChecking Player;
    public GameObject BlueMonster;
    public GameObject[] screamerBoxes;
    private int stage = 0;

    //Light mecanics
    public GameObject[] BreakableWalls;
    private GameObject[] Zone1Lights;
    private GameObject[] Zone2Lights;
    public int NumLigths,NumLigths2;


    //Audio
    public AudioSource Monster_;
    public AudioClip horror;
    public AudioClip AmbientMusic; 
    private bool horror_playing = false;
    private int horror_count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Zone1Lights=GameObject.FindGameObjectsWithTag("Light");
        Zone2Lights=GameObject.FindGameObjectsWithTag("Light2");
        NumLigths=Zone1Lights.Length;
        NumLigths2=Zone2Lights.Length;
    }

    //Carries the counting of enemies atacking the player (music related)
    public void PlayMusic(bool status){
        if(status){++horror_count;}
        else{--horror_count; if(horror_count < 0){horror_count = 0;}}
        UpdateMusic();
    }

    //Stop music
    public void PauseMusic(){
        Monster_.Stop();
    }

    //Check if action music should or should not be playing
    private void UpdateMusic(){
        if(!horror_playing && horror_count > 0){ Monster_.Stop(); Monster_.PlayOneShot(horror); horror_playing = true;}
        else if(horror_playing && horror_count <= 0){ Monster_.Stop(); Monster_.PlayOneShot(AmbientMusic); horror_playing = false;}
    }

    //General Light updater
    public void UpdateGlobal(){
        if(stage == 0){UpdateZone1Lights();}
        if(stage == 1){UpdateZone2Lights();}
    }

    //Control exiting level after completition
    public void ExitLevel(){

    }

    //Update light counter on zone 1
    private void UpdateZone1Lights(){
        NumLigths--;
        if(NumLigths==0){
            Destroy(BreakableWalls[0]);
            Player.darkness=0;
            stage = 1;
        }
    }

    //Update light counter on zone 2
    private void UpdateZone2Lights(){
        NumLigths2--;
        if(NumLigths2==0){
            Destroy(BreakableWalls[1]);
            stage = 2;
        }
    }
    
    //Activate Blue monster
    public void SummonBlueMonster(){
        BlueMonster.SetActive(true);
    }

    //Start Screamer
    public void CallScreamer(string tag){
        //Activate screamer
        if(tag == "Pink_monster"){screamerBoxes[0].SetActive(true);}
        if(tag == "Red_monster"){screamerBoxes[1].SetActive(true);}
        if(tag == "Blue_monster"){screamerBoxes[2].SetActive(true);}
        if(tag == "Orange_monster"){screamerBoxes[3].SetActive(true);}
    }
}
