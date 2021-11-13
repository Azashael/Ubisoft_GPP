/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ChangeLocale : MonoBehaviour
{
    public void OnClick(UnityEngine.Localization.Locale l)
    {
        LocalizationSettings.SelectedLocale = l;
    }
}
