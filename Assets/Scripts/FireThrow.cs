using UnityEngine;

public class FireThrow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        float mouseY = mousePosition.y;
        float mouseX = mousePosition.x;


        Debug.Log("MOUSE X: " + mouseX);
        Debug.Log("MOUSE Y: " + mouseY);


        
    }
}
