using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animationFallingParameterName;
    [SerializeField]
    private string _animatioJellyParameterName;
    [Header("Tags ground")]
    [SerializeField]
    private string _groundTag;
    [SerializeField]
    private string _jellyTag;
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody _rb;

    private int _countCollider = 0;
    private int _countJelly = 0;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            transform.position = new Vector3(transform.position.x + t.deltaPosition.x * .01f, transform.position.y, transform.position.z);
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == this._jellyTag)
        {
            this._countJelly--;
        }
        if (other.tag == this._groundTag)
        {
            this._countCollider--;

        }

        if (this._countJelly == 0)
        {
            this._animator.SetBool(this._animatioJellyParameterName, false);
        }
        else
        {
            this._animator.SetBool(this._animatioJellyParameterName, true); 
        }

        if (this._countCollider + this._countJelly == 0)
        {
            this._animator.SetBool(this._animationFallingParameterName, true);
            this._animator.SetBool(this._animatioJellyParameterName, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == this._groundTag)
        {
            this._countCollider++;
            this._animator.SetBool(this._animationFallingParameterName, false);
            this._animator.SetBool(this._animatioJellyParameterName, false);
        }
        else if(other.tag == this._jellyTag)
        {
            this._countJelly++;
            this._animator.SetBool(this._animationFallingParameterName, false);
            this._animator.SetBool(this._animatioJellyParameterName, true);
        }
    }
}
