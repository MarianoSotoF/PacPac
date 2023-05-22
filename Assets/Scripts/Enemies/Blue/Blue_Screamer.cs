using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Screamer : MonoBehaviour
{
    public Light Light;
    public GameObject enemy;
    public GameObject POV;
    public GameObject DeathScreen;

    public AudioSource Blue_monster_;
    public AudioClip monster;

    private int stage = 0;

    // Update is called once per frame
    void FixedUpdate()
    {   
        float rotationValue = 2.75f;
        float speed = 2.5f;
        if(stage == 0 && POV.transform.eulerAngles.y < 215.0f){
            POV.transform.Rotate(0, rotationValue, 0, Space.World);
            Light.transform.Rotate(0, rotationValue, 0, Space.World);
            if(POV.transform.eulerAngles.y >= 215.0f){stage = 1;}
        }
        else if(stage == 1 && POV.transform.eulerAngles.y > 145.0f){
            POV.transform.Rotate(0, -rotationValue, 0, Space.World);
            Light.transform.Rotate(0, -rotationValue, 0, Space.World);
            if(POV.transform.eulerAngles.y <= 145.0f){stage = 2;}
        }
        else if(stage == 2 && POV.transform.eulerAngles.y < 180.0f){
            enemy.transform.position += new Vector3(0,0.012f*speed,0);
            POV.transform.Rotate(-0.4f, rotationValue/2, 0, Space.World);
            Light.transform.Rotate(-0.4f, rotationValue/2, 0, Space.World);
        }
        else{
            Blue_monster_.PlayOneShot(monster);
            enemy.transform.position += new Vector3(0,0.025f*speed,0.1f*speed);
            if(Vector3.Distance(enemy.transform.position, POV.transform.position) <= 0.73f){Light.range = 0.0f; StartCoroutine(showDeathScreen());}
        }
    }

    IEnumerator showDeathScreen(){
        yield return new WaitForSeconds(0.8f);
        Destroy(this);
        DeathScreen.SetActive(true);
    }
}
