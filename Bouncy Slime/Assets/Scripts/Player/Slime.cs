using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animationName;
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
        this._animator.SetBool(this._animationName, true);
        Debug.Log("Trigger exit");
    }

    private void OnTriggerEnter(Collider other)
    {
        this._animator.SetBool(this._animationName, false);
        Debug.Log("Trigger Enter");
    }
}
