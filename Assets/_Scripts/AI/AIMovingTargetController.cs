using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovingTargetController : MonoBehaviour
{
    [SerializeField] private GameObject _aiAgent;
    private int _atPosn = 0;
    [SerializeField] private Transform[] _waypoints;

    void Start()
    {
        transform.position = _waypoints[0].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _aiAgent.gameObject)
        {
            TogglePosition();
        }
    }

    private void TogglePosition()
    {
        if (_atPosn + 1 < _waypoints.Length)
        {
            _atPosn++;
            transform.position = _waypoints[_atPosn].position;
        }
        else
        {
            _atPosn = 0;
            transform.position = _waypoints[_atPosn].position;
        }
    }
}
