using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustVectors : MonoBehaviour
{
    public Vector3 Point1;
    public Vector3 Point2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Point2, Time.deltaTime * 1);  
    }
}
