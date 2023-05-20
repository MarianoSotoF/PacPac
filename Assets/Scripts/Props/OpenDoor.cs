using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private float timeLeft = 0;
    public float timeDeltaSeconds = 3.0f;

    public void Update() {
        if(timeLeft > 0) {
            float time = Time.deltaTime;
            transform.position -= Vector3.up * ((182.62f * time / (timeDeltaSeconds * 2f)));
            timeLeft -= time;
        }
    }

    public void CloseDoor() {
        StartCoroutine(CloseDoorI());
    }

    public IEnumerator CloseDoorI() {
        timeLeft = timeDeltaSeconds;
        yield return new WaitForSeconds(timeDeltaSeconds);
        Destroy(gameObject);
    }
}