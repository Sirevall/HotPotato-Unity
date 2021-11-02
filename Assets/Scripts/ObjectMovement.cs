using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float Speed;
    public bool isForward;

    private SamuraiPath _path;
    private Vector3[] _points;
    private int _nextPoint;

    public void Start()
    {
        _path = GameObject.Find("SamuraiPath").GetComponent<SamuraiPath>();
        _points = _path.PathPoints;
        FindNextPoint();
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_nextPoint], Time.deltaTime * Speed);
        transform.LookAt(_points[_nextPoint]);
        if (transform.position == _points[_nextPoint])
        {
            FindNextPoint();
        }
    }
    private void FindNextPoint()
    {
        if (isForward)
        {
            _nextPoint++;
            if (_nextPoint >= _points.Length)
            {
                isForward = false;
                _nextPoint--;
            }
        }
        else
        {
            _nextPoint--;
            if (_nextPoint < 0)
            {
                isForward = true;
                _nextPoint = 1;
            }
        }
    }
}
