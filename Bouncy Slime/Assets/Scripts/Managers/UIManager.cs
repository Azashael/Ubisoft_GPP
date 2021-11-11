using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private InGameMenuManager _inGame;
    [SerializeField]
    private GameObject _gameOver;

    public void UpdatePoints(int pts)
    {
        this._inGame.UpdatePoints(pts);
    }
}
