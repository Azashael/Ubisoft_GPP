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
    private GameOverDisplay _gameOver;
    [SerializeField]
    private VictoryDisplay _victory;
    [SerializeField]
    private GameObject _credits;
    [SerializeField]
    private GameObject _shop;

    public void UpdatePoints(int pts)
    {
        this._inGame.UpdatePoints(pts); 
    }

    public void SetMainMenu(int level)
    {
        this._menu.SetData(level);
        this._menu.enabled = true;
    }

    public void GoToMainMenu(int level)
    {
        this._menu.SetData(level);
        this._menu.gameObject.SetActive(true);
        this._gameOver.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(false);
        this._victory.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(false);
    }

    public void GoToInGameMenu(int objective)
    {
        this._inGame.SetObjective(objective);
        this._menu.gameObject.SetActive(false);
        this._gameOver.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(true);
        this._victory.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(false);
    }

    public void GoToGameOverMenu(int score, int objective)
    {
        this._gameOver.SetScoreGameOver(score, objective);
        this._menu.gameObject.SetActive(false);
        this._gameOver.gameObject.SetActive(true);
        this._inGame.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(false);
        this._victory.gameObject.SetActive(false);
    }

    public void GoToVictoryMenu()
    {
        this._menu.gameObject.SetActive(false);
        this._gameOver.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(false);
        this._victory.gameObject.SetActive(true);
    }

    public void GoToCredits()
    {
        this._menu.gameObject.SetActive(false);
        this._gameOver.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(false);
        this._victory.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(true);
    }
}