using UnityEngine;

public class Flammable : MonoBehaviour
{
    public bool onFire;
    public bool hasBurningParticles;
    [SerializeField]
    private ParticleSystem burningParticles;
    [SerializeField]
    private float lifetime;
    private ParticleSystem particleObjRef;

    void Start()
    {
        onFire = false;
    }

    void Update()
    {
        // reduce lifetime if on fire
        if (onFire)
        {
            lifetime -= Time.deltaTime;
        }
        
        if (lifetime <= 0)
        {
            Rigidbody2D thisRb = GetComponent<Rigidbody2D>();
            HingeJoint2D[] allJoints = FindObjectsByType<HingeJoint2D>(FindObjectsSortMode.None);

            if (thisRb == null)
            {
                Debug.Log($"{name} has no Rigidbody2D, skipping burn logic.");
                Destroy(gameObject);
                return;
            }

            // When this portion burns, light the 2 connected portions on fire
            // a bunch of null checks so it doesn't try deleting an object
            // that doesn't exist or getting components that don't exist anymore
            foreach (HingeJoint2D joint in allJoints)
            {
                if (joint == null || joint.connectedBody == null)
                {
                    continue;
                }

                if (joint.connectedBody == thisRb)
                {
                    Flammable f = joint.GetComponent<Flammable>();
                    if (f != null)
                    {
                        f.onFire = true;
                    }
                }

                if (joint.attachedRigidbody == thisRb && joint.connectedBody != null)
                {
                    Flammable f = joint.connectedBody.GetComponent<Flammable>();
                    if (f != null)
                    {
                        f.onFire = true;
                    }
                }

            }

            // stop particles and set to destroy after 1.5s to allow particles to dissipate
            particleObjRef.Stop();
            Destroy(particleObjRef.gameObject, 1.5f);

            Destroy(gameObject); // delete self after lighting adjacent portions
        }


        if (onFire && !hasBurningParticles)
        {
            particleObjRef = Instantiate(burningParticles, transform.position, Quaternion.identity);
            particleObjRef.GetComponent<FollowParentPosition>().parentTransform = transform; // add follow script and set to self
            hasBurningParticles = true;
        }
    }



    // SEts onFire to true when an object tagged as fireball collides
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Fireball"))
        {
            onFire = true;
        }
    }
}
