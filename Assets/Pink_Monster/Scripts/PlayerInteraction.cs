using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        InteractRaycast();
    }

    void InteractRaycast()
    {
        Vector3 playerPosition = transform.position;
        Vector3 forwardDirection = transform.forward;

        Ray interactionRay = new Ray(playerPosition, forwardDirection);
        RaycastHit interactionRayHit;
        float interactionRayLength = 30.0f;

        Vector3 interactionRayEndpoint = forwardDirection * interactionRayLength + playerPosition;
        Debug.DrawLine(playerPosition, interactionRayEndpoint);

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
        
        if(hitFound){
            GameObject hitGameObject = interactionRayHit.transform.gameObject;

            // Interaction with Pink_monster
            if(hitGameObject.CompareTag("Pink_monster")){
                hitGameObject.SendMessage("BeenSeen", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
