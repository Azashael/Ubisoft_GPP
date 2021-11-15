/**
 * Rochelle Charline
 * Novembre 2021 
 * */

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
    private VictoryDefeatDisplayer _victorydefeat;
    [SerializeField]
    private GameObject _credits;
    [SerializeField]
    private GameObject _shop;

    public void UpdatePoints(int pts)
    {
        this._inGame.UpdatePoints(pts); 
    }

    public void GoToMainMenu(int level)
    {
        this._menu.SetData(level);

        this._menu.gameObject.SetActive(true);
        this._inGame.gameObject.SetActive(false);
        this._victorydefeat.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(false);
    }

    public void GoToInGameMenu(int objective)
    {
        this._inGame.SetObjective(objective);

        this._menu.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(true);
        this._victorydefeat.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(false);
    }

    public void GoToVictoryDefeatMenu(bool victory, int j, int dj, int tj, int jl, int r, int tr, int m)
    {
        this._victorydefeat.SetData(victory, j, dj, tj, jl, r, tr, m);

        this._menu.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(false);
        this._victorydefeat.gameObject.SetActive(true);
    }

    public void GoToCredits()
    {
        this._menu.gameObject.SetActive(false);
        this._victorydefeat.gameObject.SetActive(false);
        this._inGame.gameObject.SetActive(false);
        this._credits.gameObject.SetActive(true);
    }
}