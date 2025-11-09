using UnityEngine;

public class Lifetime : MonoBehaviour
{

    [SerializeField]
    private float lifetime;
    ParticleSystem particleSystem;

    void Update()
    {

        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0)
        {
            Destroy(gameObject);
        }

        if (lifetime <= 1f)
        {
            particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
            particleSystem.Stop();
            Transform childTransform = gameObject.transform.Find("Orb");
            if(childTransform != null)
            {
                Destroy(childTransform.gameObject);
            }
        }

    }
}
