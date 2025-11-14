using System;
using UnityEngine;
using UnityEngine.Events;


public class MatchSystem : MonoBehaviour
{
    [Header("Match Settings")]
    public float maxLightTime;
    [SerializeField] float currLightTime;

    //Eventually the visuals will be added here

    public event Action matchOut;

    private void Start()
    {
        ResetMatch();
    }


    void Update()
    {
        currLightTime -= Time.deltaTime;   
        
        if (currLightTime < 0)
        {
            matchOut.Invoke();
        }
    }

    public void ResetMatch()
    {
        maxLightTime = currLightTime;
    }
}
