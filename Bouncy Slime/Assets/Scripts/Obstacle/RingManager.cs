using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : ObstacleManager
{
    [SerializeField]
    private GameObject[] _deactivate;
    [SerializeField]
    private bool _center;

    protected override void OnTriggerEnter(Collider other)
    {
        foreach(GameObject gm in this._deactivate)
        {
            gm.SetActive(false);
        }
        if(this._center)
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
