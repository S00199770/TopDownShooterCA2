using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    //the game object we are going to follow
    public GameObject ObjectToFollow;

    //the position of where we are going to be
    Vector3 targetPosition;

    void Update()
    {
        if(ObjectToFollow != null)
        {
            //get teh X and Y position of the object we are following
            targetPosition.x = ObjectToFollow.transform.position.x;
            targetPosition.y = ObjectToFollow.transform.position.y;

            //keep our own Z position
            targetPosition.z = transform.position.z;

            //update the position of this object
            transform.position = targetPosition;
        }
    }
}
