using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishTrigger : MonoBehaviour
{
    private EndPoint[] _points;

    private void OnEnable()
    {
       _points = gameObject.GetComponentsInChildren<EndPoint>();

        foreach (var point in _points)
        {
            point.Reached += OnEndPointReached;
        }
    }

    private void OnDisable()
    {
        foreach (var point in _points)
        {
            point.Reached -= OnEndPointReached;
        }
    }

    private void OnEndPointReached()
    {
        foreach (var point in _points)
        {
            if (!point.IsReached)
            {
                return;
            }
        }

        Debug.Log("Finish");
    }
}
