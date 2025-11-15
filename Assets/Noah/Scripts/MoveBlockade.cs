using UnityEngine;
using System.Collections;

public class MoveBlockade : MonoBehaviour
{
    public GameObject Blockade;
    [SerializeField] bool ropeBroke = false;

    [Header("Transform Settings")]
    public Transform startPoint;
    public Transform endPoint;

    [Header("Speed Settings")]
    [SerializeField] float blockadeSpeed = 3.0f;



    private void Start()
    {
        Blockade.transform.position = startPoint.position;
    }
    public void BlockMove()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        while(Vector3.Distance(Blockade.transform.position, endPoint.position) >= 0.2f)
        {
            Blockade.transform.position = Vector3.Lerp(Blockade.transform.position, endPoint.position, blockadeSpeed);
            yield return null;
        }

       Blockade.transform.position = endPoint.position;

    }

}
