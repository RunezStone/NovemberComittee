using System;
using UnityEngine;

public class DynamicRope : MonoBehaviour
{
    [SerializeField] private Transform ropeEnd;
    [SerializeField] private GameObject ropePrefab;

    void Start()
    {
        // distance is just the difference in pos
        // length is the hypotenuse length
        // direction (distance normalized) is distance / magnitude
        // which basically just gives us the slope only 
        Vector3 distance = ropeEnd.position - transform.position;
        float length = distance.magnitude;
        Vector3 direction = distance.normalized;


        // ropes are 0.5 units long, number of lopes is length (hypot) divided by 0.5
        float segmentLength = 0.5f;
        int numSegments = (int)Mathf.Ceil(length / segmentLength);

        // I'm gonna pretend I know how this works but this is how you get the angle
        // from an x and y in unity. I spose.
        float ropeAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject[] segments = new GameObject[numSegments];

        // Use a single temp instance to measure local orientation OR measure per instance
        // Here we instantiate then correct each instance based on its transform.up
        for (int i = 0; i < numSegments; i++)
        {
            // sets position to base and offsets so the segments line up.
            Vector3 segmentPos = transform.position + direction * (segmentLength * i);
            GameObject seg = Instantiate(ropePrefab, segmentPos, Quaternion.Euler(0, 0, ropeAngle - 90f)); // -90 because prefab sprite is vertical. I think? Tried rotating the prefab but no dice.


            segments[i] = seg;

            Debug.Log($"Created seg {i} at {segmentPos}. Target angle: {ropeAngle}");
        }

        // connect segments to eachother (except last segment)
        for (int i = 0; i < numSegments - 1; i++)   
        {
            segments[i].GetComponent<HingeJoint2D>().connectedBody = segments[i + 1].GetComponent<Rigidbody2D>();
        }

        // finally set first rope segment to be connected to ropestart
        gameObject.GetComponent<HingeJoint2D>().connectedBody = segments[0].GetComponent<Rigidbody2D>();
    }
}
