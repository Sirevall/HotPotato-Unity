using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public GameObject Runner;
    public int CountRunners;
    public Bar bar;

    private GameObject[] _runners;
    private int _currentRunner;
    private int _nextRunner;
    private float _passDistance = 1f;

    void Start()
    {
        _currentRunner = 0;
        _nextRunner = 1;
        CreateRunners();
        FindRunnersOnScene();
        Debug.Log(_currentRunner);
        StartRunner();
    }
    public void ChooseNextRunner()
    {
        _runners[_currentRunner].GetComponent<Runner>().ToTarget.RemoveListener(ChooseNextRunner);
        _currentRunner++;
        _nextRunner++;
        ;
        if (_nextRunner == _runners.Length)
        {
            _nextRunner = 0;
        }
        else if (_currentRunner == _runners.Length)
        {
            _currentRunner = 0;
        }
        StartRunner();
    }
    private void StartRunner()
    {
        bar.GetBarRunner(_runners[_currentRunner]);
        var currentRunner = _runners[_currentRunner].GetComponent<Runner>();
        currentRunner.ToTarget.AddListener(ChooseNextRunner);
        currentRunner.StartRun(_runners[_nextRunner], _passDistance);
    }
    private void CreateRunners()
    {
        Vector3 center = transform.position;
        float radius = CountRunners * 2.0f;
        float angle = 360 / CountRunners;
        for (int i = 0; i < CountRunners; i++)
        {
            float anglePosition = angle * i + 1;
            Vector3 position = SpawnCircle(center, radius, anglePosition);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, center - position);
            Instantiate(Runner, position, rotation);
        }
    }
    private Vector3 SpawnCircle(Vector3 center, float radius, float angle)
    {
        Vector3 position;
        position.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        position.y = center.y;
        return position;
    }
    private void FindRunnersOnScene()
    {
        _runners = GameObject.FindGameObjectsWithTag("Runner");
    }
}
