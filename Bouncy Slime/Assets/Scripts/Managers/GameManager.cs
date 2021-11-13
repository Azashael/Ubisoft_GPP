using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance { get { return s_Instance; } }

    public bool PauseGameValue { get => this._pauseGame; }
    public bool Vibration { get => _vibration; }

    static protected GameManager s_Instance;

    [Header("Managers")]
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private LevelManager _levelManager;
    [SerializeField]
    private Slime _player;
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
    [SerializeField]
    private string _keyVibration;
    [SerializeField]
    private int _keySkinPlayer;


    private int _nextLevel;
    private int _nextLevelLimit;
    private int _moneyOwned;
    private int _skinPlayer = 0;

    private bool _pauseGame = true;
    private bool _vibration;

    void Start()
    {
        s_Instance = this;

        GetPlayerPref();

        SetLevel();

        SetMainMenu();

        PauseGame();

        Debug.Log("Start GameManager");
    }

    public void InversePauseGame()
    {
        Debug.Log("InversePauseGame : " + this._pauseGame);
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
        Debug.Log("PauseGame");
        this._pauseGame = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame");
        this._pauseGame = false;
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        ResumeGame();
        this._uiManager.GoToInGameMenu(this._nextLevelLimit);
        this._levelManager.StartMoving();
        this._player.StartMoving();
    }

    public void UpdatePoints(int pts)
    {
        this._uiManager.UpdatePoints(pts);
    }

    private void GetPlayerPref()
    {
        GetLevel();
        GetMoney();
        GetVibration();
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
            SaveLevel();
        }
    }

    private void SaveLevel()
    {
        PlayerPrefs.SetInt(this._keyLevel, this._nextLevel);
        PlayerPrefs.Save();
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

    private void SaveMoney()
    {
        PlayerPrefs.SetInt(this._keyMoney, this._moneyOwned);
        PlayerPrefs.Save();
    }

    private void GetVibration()
    {
        if (PlayerPrefs.HasKey(this._keyVibration))
        {
            this._vibration = (PlayerPrefs.GetInt(this._keyVibration) == 1) ? true : false;
        }
        else
        {
            this._vibration = true;
            PlayerPrefs.SetInt(this._keyVibration, 1);
            PlayerPrefs.Save();
        }
    }

    private void SaveVibration()
    {
        PlayerPrefs.SetInt(this._keyVibration, (this._vibration) ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SetVibration(bool v)
    {
        this._vibration = v;
        PlayerPrefs.SetInt(this._keyVibration, (this._vibration) ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ReverseVibration()
    {
        this._vibration = !this._vibration;
        SaveVibration();
    }

    private void SetLevel()
    {
        this._levelManager.SetLevelLength(this._levelMaxLength);
        this._levelManager.StartPath();
        this._levelManager.gameObject.SetActive(true);
    }

    private void SetMainMenu()
    {
        this._uiManager.SetMainMenu(this._nextLevel);
    }

    public void Victory()
    {
        this._uiManager.GoToVictoryMenu();
        this._levelManager.EndLevel();
        this._nextLevel++;
        this._nextLevelLimit = this._levelMaxLength + (this._incrementLevelMaxLength * (this._nextLevel - 1));
        SaveLevel();
        SetLevel();
        PauseGame();
    }

    public void Defeat(int score)
    {
        this._uiManager.GoToGameOverMenu(score, this._nextLevelLimit);
        this._levelManager.EndLevel();
        SetLevel();
        PauseGame();
    }

    public void ReturnToMainMenu()
    {
        this._uiManager.GoToMainMenu(this._nextLevel);
        PauseGame();
    }
}
