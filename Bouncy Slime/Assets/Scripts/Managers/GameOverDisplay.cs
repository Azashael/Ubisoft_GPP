/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    [Header("Texte")]
    [SerializeField]
    private Text _score;
    [SerializeField]
    private string _separator;

    public void SetScoreGameOver(int score, int limit)
    {
        this._score.text = string.Concat(score.ToString(), this._separator, limit.ToString());
    }
}
