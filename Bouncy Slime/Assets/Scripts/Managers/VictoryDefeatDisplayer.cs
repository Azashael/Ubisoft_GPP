/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryDefeatDisplayer : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField]
    private Text _textJump;
    [SerializeField]
    private Text _textDoubleJump;
    [SerializeField]
    private Text _textTripleJump;
    [SerializeField]
    private Text _textJelly;
    [SerializeField]
    private Text _textRings;
    [SerializeField]
    private Text _textTouchedRings;
    [SerializeField]
    private Text _combo;
    [Header("Victory")]
    [SerializeField]
    private GameObject _victoryTitle;
    [SerializeField]
    private GameObject _victoryButton;
    [Header("Defeat")]
    [SerializeField]
    private GameObject _defeatTitle;
    [SerializeField]
    private GameObject _defeatButton;

    public void SetData(bool victory, int j, int dj, int tj, int jl, int r, int tr, int m)
    {
        this._victoryTitle.SetActive(victory);
        this._defeatTitle.SetActive(!victory);

        this._victoryButton.SetActive(victory);
        this._defeatButton.SetActive(!victory);

        this._textJump.text = j.ToString();
        this._textDoubleJump.text = dj.ToString();
        this._textTripleJump.text = tj.ToString();
        this._textJelly.text = jl.ToString();
        this._textRings.text = r.ToString();
        this._textTouchedRings.text = tr.ToString();
        this._combo.text = m.ToString();
    }
}