/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.PropertyVariants;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class ShowHideOnClick : MonoBehaviour
{
    [Header("Object to show/hide")]
    [SerializeField]
    private GameObject _object;
    [Header("Object to hide")]
    [SerializeField]
    private GameObject _hide;

    public void Start()
    {
        this._object.SetActive(false);
    }

    public void OnClick()
    {
        this._object.SetActive(!this._object.activeSelf);
        this._hide.SetActive(false);
    }
}
