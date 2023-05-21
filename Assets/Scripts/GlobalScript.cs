using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public CollisionChecking Player;
    public GameObject BlueMonster;
    public GameObject[] BreakableWalls;
    GameObject[] Zone1Lights;
    GameObject[] Zone2Lights;
    public int NumLigths,NumLigths2;
    
    // Start is called before the first frame update
    void Start()
    {
        Zone1Lights=GameObject.FindGameObjectsWithTag("Light");
        Zone2Lights=GameObject.FindGameObjectsWithTag("Light2");
        NumLigths=Zone1Lights.Length;
        NumLigths2=Zone2Lights.Length;
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void UpdateZone1Lights(){
        NumLigths--;
        if(NumLigths==0){
            Destroy(BreakableWalls[0]);
            Player.darkness=0;
        }

    }
    public void UpdateZone2Lights(){
        NumLigths2--;
        if(NumLigths2==0){
            Destroy(BreakableWalls[1]);
        }

    }
    public void InOrangeMonsterZone(){

    }
    public void SummonBlueMonster(){
        BlueMonster.SetActive(true);

    }
}
