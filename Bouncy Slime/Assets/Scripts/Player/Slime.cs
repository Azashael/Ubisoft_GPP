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
    [SerializeField]
    private string _animationGoParameterName;
    [Header("Tags ground")]
    [SerializeField]
    private string _groundTag;
    [SerializeField]
    private string _jellyTag;
    [SerializeField]
    private string _endTag;
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody _rb;

    private int _countCollider = 0;
    private int _countJelly = 0;
    private int _countJump = 0;

    private void Update()
    {
        if (!GameManager.instance.PauseGameValue)
        {
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                transform.position = new Vector3(transform.position.x + t.deltaPosition.x * .01f, transform.position.y, transform.position.z);
            }
        }
    }

    public void StartMoving()
    {
        this._animator.SetBool(this._animationGoParameterName, true);
    }

    public void StopMoving()
    {
        this._animator.SetBool(this._animationGoParameterName, false);
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
        else if(other.tag == this._endTag)
        {
            this._animator.SetBool(this._animationGoParameterName, false);
            this._animator.SetBool(this._animatioJellyParameterName, false);
            this._animator.SetBool(this._animationFallingParameterName, false);
            Victory();
        }
    }

    public void Defeat()
    {
        GameManager.instance.Defeat(this._countJump);
        ResetAnimation();
        ResetCounter();
    }

    public void Victory()
    {
        GameManager.instance.Victory();
        ResetAnimation();
        ResetCounter();
    }

    private void ResetCounter()
    {
        this._countCollider = 0;
        this._countJelly = 0;
        this._countJump = 0;
    }

    private void ResetAnimation()
    {
        this._animator.Rebind();
        transform.position = new Vector3(0, 1, 0);
    }

    private void CountPoints()
    {
        this._countJump++;
        GameManager.instance.UpdatePoints(this._countJump);
    }

    void OnBounce()
    {
        if (GameManager.instance.Vibration)
            Handheld.Vibrate();
    }
}
