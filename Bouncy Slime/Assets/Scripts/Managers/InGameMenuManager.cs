using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuManager : MonoBehaviour
{
    [Header("Score zone")]
    [SerializeField]
    private Text _rightPlayerScore;
    [SerializeField]
    private Text _leftLevelScore;
    [SerializeField]
    private Slider _slideScore;

    public void UpdatePoints(int pts)
    {
        this._rightPlayerScore.text = pts.ToString();
        this._slideScore.value = pts;
    }
}
