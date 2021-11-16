using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollider : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private Slime _root;
    [SerializeField]
    private string _wallTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == this._wallTag)
        {
            this._root.Defeat();
        }
    }
}
