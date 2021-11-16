using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingManager : ObstacleManager
{
    [SerializeField]
    private GameObject[] _deactivate;
    [SerializeField]
    private bool _center;
    [SerializeField]
    private Text _points;
    [SerializeField]
    private string _animTextKey;

    protected override void OnTriggerEnter(Collider other)
    {
        foreach(GameObject gm in this._deactivate)
        {
            gm.SetActive(false);
        }
        if(this._center)
        {
            this._points.text = "+" + GameManager.instance.UpdateRingPoints().ToString();
            base._animator.SetTrigger(this._animTextKey);
        }
        else
        {
            GameManager.instance.UpdateRingTouchedCount();
        }
        base.OnTriggerEnter(other);
    }
}