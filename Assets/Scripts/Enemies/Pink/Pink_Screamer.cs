using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink_Screamer : MonoBehaviour
{
    public Light Light;
    public GameObject enemy;
    public GameObject POV;
    public GameObject DeathScreen;

    // Update is called once per frame
    void FixedUpdate()
    {   
        float increment = 1.015f;
        if(Light.intensity < 4.0f){Light.intensity *= increment; Light.spotAngle *= increment;}
        else{
            float speed = 2.35f;

            enemy.transform.position += new Vector3(0,-0.025f*speed,0.1f*speed);
            if(Vector3.Distance(enemy.transform.position, POV.transform.position) <= 7.5f){Light.range = 0.0f; StartCoroutine(showDeathScreen());}
        }
    }

    IEnumerator showDeathScreen(){
        yield return new WaitForSeconds(0.8f);
        Destroy(this);
        DeathScreen.SetActive(true);
    }
}
