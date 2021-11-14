using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animationParameter;
    [SerializeField]
    private string _tagPlayer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision ! Me : " + this.tag + " ; Other :" + other.gameObject.tag);
        if (other.gameObject.tag == this._tagPlayer)
        { 
            this._animator.SetTrigger(this._animationParameter);
        }
    }
}
