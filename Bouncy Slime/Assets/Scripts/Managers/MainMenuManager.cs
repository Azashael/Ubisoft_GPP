/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Composants")]
    [SerializeField]
    private LevelDisplayer _levelDisplay;

    public void SetData(int level)
    {
        this._levelDisplay.SetLevel(level);
    }
}
