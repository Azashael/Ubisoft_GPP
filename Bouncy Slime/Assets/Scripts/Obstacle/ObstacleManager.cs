using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    protected string _animationParameter;
    [SerializeField]
    protected string _tagPlayer;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == this._tagPlayer)
        {
            this._animator.SetTrigger(this._animationParameter);
        }
    }
}
