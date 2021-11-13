/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideOnClick : MonoBehaviour
{
    [Header("Object to show/hide")]
    [SerializeField]
    private GameObject _object;

    public void Start()
    {
        this._object.SetActive(false);
    }

    public void OnClick()
    {
        this._object.SetActive(!this._object.activeSelf);
    }
}
