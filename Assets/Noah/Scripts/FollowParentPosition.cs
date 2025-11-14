using UnityEngine;

public class FollowParentPosition : MonoBehaviour
{
    public Transform parentTransform;

    // all this script does is attatch the particle system to the fire particle
    // but just the transform no rotation, so fire always leaves the top.
    void Update() 
    {
        if (parentTransform != null)
        {
            transform.position = parentTransform.position;
        }
    }
}
