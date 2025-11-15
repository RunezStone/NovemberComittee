using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float damping;

    public Transform target;

    [SerializeField] Vector3 vel = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);

    }
}
