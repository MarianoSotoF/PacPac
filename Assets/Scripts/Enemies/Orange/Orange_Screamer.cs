using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_Screamer : MonoBehaviour
{
    public Light Light;
    public GameObject enemy;
    public GameObject POV;
    public GameObject DeathScreen;

    public AudioSource Orange_monster_;
    public AudioClip monster;
    
    // Update is called once per frame
    void FixedUpdate()
    {   
        float rotationValue = 1.75f;
        float speed = 0.45f;
        if(POV.transform.eulerAngles.y < 180.0f){
            rotationValue *= 1.75f;
            POV.transform.Rotate(0, rotationValue, 0, Space.World);
            Light.transform.Rotate(0, rotationValue, 0, Space.World);
        }
        else{
            Orange_monster_.PlayOneShot(monster);
            enemy.transform.position += new Vector3(0, 0, speed);
            if(Vector3.Distance(enemy.transform.position, POV.transform.position) <= 1.6f){Light.range = 0.0f; StartCoroutine(showDeathScreen());}
        }
    }

    IEnumerator showDeathScreen(){
        yield return new WaitForSeconds(0.7f);
        Destroy(this);
        DeathScreen.SetActive(true);
    }
}
