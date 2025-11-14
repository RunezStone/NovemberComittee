using UnityEngine;

public class Lifetime : MonoBehaviour
{

    [SerializeField]
    private float lifetime;
    private ParticleSystem fireParticles;

    void Update()
    {

        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0)
        {
            Destroy(gameObject);
        }

        if (lifetime <= 1f)
        {
            fireParticles = gameObject.GetComponentInChildren<ParticleSystem>();
            fireParticles.Stop();
            Transform childTransform = gameObject.transform.Find("Orb");
            if(childTransform != null)
            {
                Destroy(childTransform.gameObject);
            }
        }

    }
}
