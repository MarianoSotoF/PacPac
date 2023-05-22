using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lv1_GlobalScript : MonoBehaviour
{
    public CollisionChecking Player;
    public GameObject BlueMonster;
    public GameObject[] BreakableWalls;
    GameObject[] Zone1Lights;
    GameObject[] Zone2Lights;
    public int NumLigths,NumLigths2;

    private int stage = 0;

    public AudioSource Monster_;
    public AudioClip horror;
    public AudioClip AmbientMusic; 

    private bool horror_playing = false;
    public int horror_count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Zone1Lights=GameObject.FindGameObjectsWithTag("Light");
        Zone2Lights=GameObject.FindGameObjectsWithTag("Light2");
        NumLigths=Zone1Lights.Length;
        NumLigths2=Zone2Lights.Length;
    }

    public void PlayMusic(bool status){
        if(status){++horror_count;}
        else{--horror_count; if(horror_count < 0){horror_count = 0;}}
        UpdateMusic();
    }

    public void PauseMusic(){
        Monster_.Stop();
    }

    private void UpdateMusic(){
        if(!horror_playing && horror_count > 0){ Monster_.Stop(); Monster_.PlayOneShot(horror); horror_playing = true;}
        else if(horror_playing && horror_count <= 0){ Monster_.Stop(); Monster_.PlayOneShot(AmbientMusic); horror_playing = false;}
    }

    public void UpdateGlobal(){
        if(stage == 0){UpdateZone1Lights();}
        if(stage == 1){UpdateZone2Lights();}
    }

    public void ExitLevel(){

    }

    private void UpdateZone1Lights(){
        NumLigths--;
        if(NumLigths==0){
            Destroy(BreakableWalls[0]);
            Player.darkness=0;
            stage = 1;
        }
    }

    private void UpdateZone2Lights(){
        NumLigths2--;
        if(NumLigths2==0){
            Destroy(BreakableWalls[1]);
            stage = 2;
        }
    }
    
    public void SummonBlueMonster(){
        BlueMonster.SetActive(true);
    }
}
