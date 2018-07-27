using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour {

    public Transform player = null;
    public Transform target = null;
    public float speed = 5.0f;
    public Vector3 nextPosition = Vector3.zero;
    public enum CameraState { none, both,lookAtPlayer };
    public CameraState cameraState = CameraState.none;
   

    private void LateUpdate()
    {
        switch (cameraState)
        {
            case CameraState.none: break;
            case CameraState.both:  FollowPosition(); LookAtPlayer(); break;
            case CameraState.lookAtPlayer: LookAtPlayer(); break;
        }

        
    }

    void FollowPosition()
    {
        nextPosition.x = Mathf.Lerp(this.transform.position.x, target.position.x, speed * Time.deltaTime);
        nextPosition.y = Mathf.Lerp(this.transform.position.y, target.position.y, speed * Time.deltaTime);
        nextPosition.z = Mathf.Lerp(this.transform.position.z, target.position.z, speed * Time.deltaTime);

        //this.transform.position = target.position; This is very limited
        this.transform.position = nextPosition;
    }
    void LookAtPlayer()
    {
        this.transform.LookAt(player.position);  // Rotates the camera to look at the player
    }
}
