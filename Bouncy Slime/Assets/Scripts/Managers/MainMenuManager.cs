using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Composants")]
    [SerializeField]
    private LevelDisplayer _levelDisplay;
    [SerializeField]
    private Text _moneyDisplay;

    public void SetData(int level, int money)
    {
        this._levelDisplay.SetLevel(level);
        this._moneyDisplay.text = money.ToString();
    }
}
