using System;
using UnityEngine;

public class OrbCollider : MonoBehaviour
{    
    [SerializeField]
    public string playerObjectName;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Candle"))
        {
            Debug.Log($"Detected 2D collider: " + collision.gameObject.name);
            // Get fire throw component from player in order to use teleport method
            FireThrow fireThrow = GameObject.Find(playerObjectName).GetComponent<FireThrow>();
            fireThrow.TeleportPlayerToCandle(collision.transform.position);

            // destory candle
            Destroy(collision.gameObject);

            // disable self collider and pause particle system
            // projectile will automatically be deleted by Lifetime script already
            ParticleSystem fireParticles = gameObject.transform.parent.parent.GetComponentInChildren<ParticleSystem>();
            fireParticles.Stop();
            gameObject.GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject); // destroy this object so no more collisions happen
        }

    }
}

