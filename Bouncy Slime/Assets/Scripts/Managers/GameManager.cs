using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance { get { return s_Instance; } }

    public bool PauseGameValue { get => this._pauseGame; }

    static protected GameManager s_Instance;

    [Header("Managers")]
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private LevelManager _levelManager;
    [Header("Calibrage")]
    [SerializeField]
    private int _levelMaxLength;
    [SerializeField]
    private int _incrementLevelMaxLength;
    [Header("PlayerPref")]
    [SerializeField]
    private string _keyLevel;
    [SerializeField]
    private string _keyMoney;


    private int _nextLevel;
    private int _nextLevelLimit;
    private int _moneyOwned;

    private bool _pauseGame = true;

    void Start()
    {
        s_Instance = this;

        GetPlayerPref();

        SetLevel();

        PauseGame();
    }

    void Update()
    {
        
    }

    public void InversePauseGame()
    {
        if(this._pauseGame)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        this._pauseGame = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        this._pauseGame = false;
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        ResumeGame();
        this._uiManager.GoToInGameMenu(this._nextLevelLimit);
    }

    public void UpdatePoints(int pts)
    {
        this._uiManager.UpdatePoints(pts);
    }

    private void GetPlayerPref()
    {
        GetLevel();
        GetMoney();
    }

    private void GetLevel()
    {
        if (PlayerPrefs.HasKey(this._keyLevel))
        {
            this._nextLevel = PlayerPrefs.GetInt(this._keyLevel);
            this._nextLevelLimit = this._levelMaxLength + (this._incrementLevelMaxLength * (this._nextLevel - 1));
        }
        else
        {
            this._nextLevel = 1;
            this._nextLevelLimit = this._levelMaxLength + (this._incrementLevelMaxLength * (this._nextLevel - 1));
            PlayerPrefs.SetInt(this._keyLevel, 1);
            PlayerPrefs.Save();
        }
    }

    private void GetMoney()
    {
        if (PlayerPrefs.HasKey(this._keyMoney))
        {
            this._moneyOwned = PlayerPrefs.GetInt(this._keyMoney);
        }
        else
        {
            this._moneyOwned = 0;
            PlayerPrefs.SetInt(this._keyMoney, 0);
            PlayerPrefs.Save();
        }
    }

    private void SetLevel()
    {
        this._levelManager.SetLevelLength(this._levelMaxLength);
        this._levelManager.gameObject.SetActive(true);
    }

    private void SetMainMenu()
    {
        this._uiManager.SetMainMenu(this._nextLevel, this._moneyOwned);
    }
}
