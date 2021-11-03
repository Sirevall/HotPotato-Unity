using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Runner : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _speed = 3f;
    private bool _run = false;
    private Transform _runner;
    private float _passDistance;
    private bool _runBack = false;

    public UnityEvent ToTarget;
    void Start()
    {
        _startPosition = transform.position;
    }
    private void Update()
    {
        if (_run)
        {
            Run(_runner, _passDistance);
        }
        if (_runBack)
        {
            RunBack();
        }
    }
    public void Run(Transform runner, float passDistance)
    { 
        transform.position = Vector3.MoveTowards(transform.position, runner.transform.position, Time.deltaTime * _speed);
        transform.LookAt(runner.transform.position);
        float dist = Vector3.Distance(transform.position, runner.transform.position);
        if (dist < passDistance)
        {
            _run = false;
            _runBack = true;
            _speed++;
            ToTarget.Invoke();
        }
    }
    private void RunBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, Time.deltaTime * _speed);
        transform.LookAt(_startPosition);
        if (transform.position == _startPosition)
        {
            _runBack = false;
            _speed--;
            GetComponent<Animation>().Stop();
        }
    }
    public void StartRun(GameObject runner, float passDistance)
    {
        GetComponent<Animation>().Play();
        _run = true;
        _runner = runner.GetComponent<Transform>();
        _passDistance = passDistance;
    }
}
