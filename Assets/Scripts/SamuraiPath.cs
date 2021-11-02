using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiPath : MonoBehaviour
{
    public GameObject PointObject;
    public int CountPoints;

    private Vector3[] _pathPoints;

    public void Awake()
    {
        CreateArrayPoints();
        SpawnPointObjects();
    }
    public Vector3[] PathPoints
    {
        get => _pathPoints;
    }
    private void CreateArrayPoints()
    {
        if (CountPoints < 2)
        {
            CountPoints = 2;
        }
        _pathPoints = new Vector3[CountPoints];
        for (int i = 0; i < _pathPoints.Length; i++)
        {
            _pathPoints[i] = new Vector3(Random.Range(-20.0f,20.0f), 0, Random.Range(-20.0f, 20.0f));
        }
    }
    private void SpawnPointObjects()
    {
        for (int i = 0; i < _pathPoints.Length; i++)
        {
            Instantiate(PointObject, _pathPoints[i], Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
        }   
    }
}
