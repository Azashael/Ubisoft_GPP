using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private MainMenuManager _menu;
    [SerializeField]
    private InGameMenuManager _inGame;
    [SerializeField]
    private GameObject _gameOver;



    public void UpdatePoints(int pts)
    {
        this._inGame.UpdatePoints(pts);
    }

    public void SetMainMenu(int level, int money)
    {
        this._menu.SetData(level, money);
        this._menu.enabled = true;
    }

    public void GoToInGameMenu()
    {
        this._menu.gameObject.SetActive(false);
        this._gameOver.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(true);
    }
}