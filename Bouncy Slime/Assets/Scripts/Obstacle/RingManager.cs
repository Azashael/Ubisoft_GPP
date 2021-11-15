using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : ObstacleManager
{
    [Header("Config")]
    [SerializeField]
    private bool _center;

    protected override void OnTriggerEnter(Collider other)
    {
        if(_center)
        {
            GameManager.instance.UpdateRingPoints();
        }
        else
        {
            GameManager.instance.UpdateRingTouchedCount();
        }
        base.OnTriggerEnter(other);
    }
}
