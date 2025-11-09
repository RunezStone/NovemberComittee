using System;
using UnityEngine;

public class OrbCollider : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask targetLayer;


    // finds candles within radius, and if found, teleports player to candle
    void Update()
    {
        
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, targetLayer);

        // If a collider is in range
        if (hitCollider != null)
        {
            // Debug.Log($"Detected 2D collider: " + hitCollider.gameObject.name);
            // Get fire throw component from player in order to use teleport method
            FireThrow fireThrow = GameObject.Find("PlayerPlaceholder").GetComponent<FireThrow>();
            fireThrow.TeleportPlayerToCandle(hitCollider.transform.position);

            // destory candle
            Destroy(hitCollider);

            // disable self collider and pause particle system
            // projectile will automatically be deleted by Lifetime script already
            ParticleSystem fireParticles = gameObject.transform.parent.GetComponentInChildren<ParticleSystem>();
            fireParticles.Stop();
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}

