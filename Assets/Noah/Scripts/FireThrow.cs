using System;
using Unity.Mathematics;
using UnityEngine;

public class FireThrow : MonoBehaviour
{
    public Transform reticleObject;
    private Transform reticle;

    [SerializeField]
    private float range = 3f;
    [SerializeField]
    private float throwForce = 3f;


    // Projectile to shoot on click
    [SerializeField]
    public GameObject projectile;

    // Update is called once per frame
    void Start()
    {
        reticle = Instantiate(reticleObject);
    }
    void Update()
    {
        if(!PauseMenu.isPaused) // no fire throw logic when paused
        {
            Vector3 mousePosition = Input.mousePosition;

            float mouseY = mousePosition.y;
            float mouseX = mousePosition.x;

            // source position is player transform
            Vector3 sourcePosition = transform.position;

            // Input.mousePosition is screen space, needs to be in world space to compare to player transform
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0; // somehow the mouse is not at z = 0, set it there.

            Vector3 direction = targetPosition - sourcePosition;

            // Debug.Log("SourcePos: " + sourcePosition);
            // Debug.Log("Direction: " + direction);

            // clamp aim direction to range
            Vector3 adjustedDirection = ClampToCircle(direction, range);

            // set reticle position to clamped aim
            reticle.position = sourcePosition + adjustedDirection;


            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                ShootProjectile(adjustedDirection);
            }
        }

    }

    public Vector3 ClampToCircle(Vector3 position, float maxDistance)
    {
        // finds hypotenuse distance vector c = sqrt(a^2 + b^2)
        float distance = Mathf.Sqrt(position.x * position.x + position.y * position.y);

        if (distance > maxDistance)
        {
            // scale so hypotenuse is under maxDistance
            float scale = maxDistance / distance; 
            position.x *= scale;
            position.y *= scale;
        }

        return position;
    }


    public void ShootProjectile(Vector3 adjustedDirection)
    {
        // create new proj at player position (quaternion identity means no rotation)
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);

        Transform orbTransform = proj.transform.Find("Orb");
        if (orbTransform == null) // Debugs since it's fighting me
        {
            Debug.LogError("No child named orb found on projectile prefab");
            return;
        }

        Rigidbody2D rb = orbTransform.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("orb child has no Rigidbody2D component");
            return;
        }

        rb.AddForce(adjustedDirection * throwForce, ForceMode2D.Impulse);
        // Debug.Log("Force applied: " + adjustedDirection * throwForce);
    }
    
    public void TeleportPlayerToCandle(Vector3 newPos)
    {
        transform.position = newPos;
    }
}
