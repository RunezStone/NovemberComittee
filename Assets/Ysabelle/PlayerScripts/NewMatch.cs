using UnityEngine;

public class NewMatch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            Debug.Log("Player Hit Match");
        }
    }
}
