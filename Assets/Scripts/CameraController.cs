using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform pTranform;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime = 1;

    // Update is called once per frame
    void Update()
    {
        // Set the camera to follow the player only while they're above the screen.
        if (pTranform.position.y > -1)
        {
            CameraFollow();
        }
         
    }

    void CameraFollow()
    {   
        // Set the target position for the camera to move to based off the player's position.
        Vector3 targetPosition = new Vector3(transform.position.x, pTranform.position.y, transform.position.z);

        // Move the Camera to the new posiiton while also smoothing out the movement.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
       
    }
}
