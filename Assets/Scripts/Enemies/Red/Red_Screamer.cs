using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Screamer : MonoBehaviour
{
    public Light Light;
    public GameObject enemy;
    public GameObject POV;
    public GameObject DeathScreen;

    private float TotalRotation = 0.0f;
    private int stage = 0;

    // Update is called once per frame
    void FixedUpdate()
    {   
        float rotationValue = 1.75f;
        float speed = 0.2f;

        if(stage == 0 && POV.transform.eulerAngles.y < 230.0f){
            POV.transform.Rotate(0, rotationValue/1.5f, 0, Space.World);
            Light.transform.Rotate(0, rotationValue/1.5f, 0, Space.World);
            if(POV.transform.eulerAngles.y >= 230.0f){stage = 1;}
        }
        else if(stage == 1 && POV.transform.eulerAngles.y > 130.0f){
            POV.transform.Rotate(0, -rotationValue/1.25f, 0, Space.World);
            Light.transform.Rotate(0, -rotationValue/1.25f, 0, Space.World);
            if(POV.transform.eulerAngles.y <= 130.0f){stage = 2;}
        }
        else if(stage == 2 && POV.transform.eulerAngles.y < 160.0f){
            POV.transform.Rotate(0, rotationValue, 0, Space.World);
            Light.transform.Rotate(0, rotationValue, 0, Space.World);
            if(POV.transform.eulerAngles.y >= 160.0f){stage = 3;}
        }
        else if(stage == 3 && TotalRotation < 90.0f){
            TotalRotation += rotationValue;
            POV.transform.Rotate(-rotationValue, 0, 0, Space.Self);
            Light.transform.Rotate(-rotationValue, 0, 0, Space.Self);
        }
        else{
            enemy.transform.position += new Vector3(0,-speed,0);
            if(Vector3.Distance(enemy.transform.position, POV.transform.position) <= 1.0f){Light.range = 0.0f; StartCoroutine(showDeathScreen());}
        }
    }

    IEnumerator showDeathScreen(){
        yield return new WaitForSeconds(0.8f);
        Destroy(this);
        DeathScreen.SetActive(true);
    }
}
