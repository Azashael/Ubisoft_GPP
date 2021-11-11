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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        this._animator.SetBool(this._animationFallingParameterName, true);
        this._animator.SetBool(this._animatioJellyParameterName, false);
        Debug.Log("Trigger exit " + other.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == this._groundTag)
        {
            this._animator.SetBool(this._animationFallingParameterName, false);
            this._animator.SetBool(this._animatioJellyParameterName, false);
        }
        else if(other.tag == this._jellyTag)
        {
            this._animator.SetBool(this._animationFallingParameterName, false);
            this._animator.SetBool(this._animatioJellyParameterName, true);
        }
        Debug.Log("Trigger enter " + other.tag);
    }
}
