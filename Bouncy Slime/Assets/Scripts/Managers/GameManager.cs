/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    static public GameManager instance { get { return s_Instance; } }
    public bool PauseGameValue { get => this._pauseGame; }
    public bool Vibration { get => _vibration; }
    public int SkinPlayer { get => _skinPlayer; }

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
    private string _keySkinPlayer;
    [SerializeField]
    private string _keyLocale;

    // Niveau Actuel
    private int _nextLevel;
    private int _nextLevelLimit;

    // Données joueur
    private int _skinPlayer = 0;

    // Option Joueur
    private bool _pauseGame = true;
    private bool _vibration;
    private string _locale;

    // Statistique Niveau en cours
    private int _nbJump = 0;
    private int _nbDoubleJump = 0;
    private int _nbTripleJump = 0;
    private int _nbJelly = 0;
    private int _nbRings = 0;
    private int _nbTouchedRing = 0;
    private int _distance = 0;
    private int _bonus = 0;

    private int _nbRingCombo = 0;
    private int _nbRingComboMax = 0;

    void Start()
    {
        s_Instance = this;

        GetPlayerPref();

        SetLevel();

        SetMainMenu();

        PauseGame();
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
        this._levelManager.StartMoving();
        this._player.StartMoving();
    }

    public void UpdatePoints(int pts)
    {
        this._distance = pts;
        if(pts + this._bonus > this._nextLevelLimit)
            this._uiManager.UpdatePoints(this._nextLevelLimit);
        else
            this._uiManager.UpdatePoints(pts + this._bonus);
    }

    public int GetPoints()
    {
        return this._distance + this._bonus;
    }

    public void SetStatJump(int j, int dj, int tj)
    {
        this._nbJump = j;
        this._nbDoubleJump = dj;
        this._nbTripleJump = tj;
        this._nbJelly = dj + tj;
    }

    public int UpdateRingPoints()
    {
        this._nbRingCombo++;
        this._nbRings++;
        this._bonus += this._nbRingCombo;
        UpdatePoints(this._distance);
        this._nbRingComboMax = (this._nbRingComboMax < this._nbRingCombo) ? this._nbRingCombo : this._nbRingComboMax;
        return this._nbRingCombo;
    }

    public void UpdateRingTouchedCount()
    {
        this._nbRingComboMax = (this._nbRingComboMax < this._nbRingCombo) ? this._nbRingCombo : this._nbRingComboMax;
        this._nbRingCombo = 0;
        this._nbTouchedRing++;
    }

    private void ResetStats()
    {
        this._nbJump = 0;
        this._nbDoubleJump = 0;
        this._nbTripleJump = 0;
        this._nbJelly = 0;
        this._nbRings = 0;
        this._nbTouchedRing = 0;
        this._distance = 0;
        this._nbRingCombo = 0;
        this._bonus = 0;
        this._nbRingComboMax = 0;
    }

    private void GetPlayerPref()
    {
        GetLevel();
        GetVibration();
        GetSkin();
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

    private void GetLocale()
    {
        if (PlayerPrefs.HasKey(this._keyLocale))
        {
            this._locale = PlayerPrefs.GetString(this._keyLocale);
        }
        else
        {
            this._vibration = true;
            PlayerPrefs.SetString(this._keyLocale, this._locale);
            PlayerPrefs.Save();
        }
    }

    private void SaveLocale()
    {
        PlayerPrefs.SetString(this._keyLocale, this._locale);
        PlayerPrefs.Save();
    }

    private void SetLocale(Locale l)
    {
        this._locale = l.ToString();
        PlayerPrefs.SetString(this._keyLocale, this._locale);
        PlayerPrefs.Save();
    }

    private void GetSkin()
    {
        if (PlayerPrefs.HasKey(this._keySkinPlayer))
        {
            this._skinPlayer = PlayerPrefs.GetInt(this._keySkinPlayer);
        }
        else
        {
            this._skinPlayer = 0;
            PlayerPrefs.SetInt(this._keySkinPlayer, this._skinPlayer);
            PlayerPrefs.Save();
        }
    }

    private void SaveSkin()
    {
        PlayerPrefs.SetInt(this._keySkinPlayer, this._skinPlayer);
        PlayerPrefs.Save();
    }

    private void SetSkin(int s)
    {
        this._skinPlayer = s;
        PlayerPrefs.SetInt(this._keySkinPlayer, this.SkinPlayer);
        PlayerPrefs.Save();
    }

    public void ReverseVibration()
    {
        this._vibration = !this._vibration;
        SaveVibration();
    }

    public void SetSkinMenu(int s)
    {
        this._skinPlayer = s;
        SaveSkin();
        this._levelManager.ApplySkin();
    }

    private void SetLevel()
    {
        this._levelManager.SetLevelLength(this._nextLevelLimit);
        this._levelManager.StartPath();
        this._levelManager.gameObject.SetActive(true);
        this._levelManager.ApplySkin();
    }

    private void SetMainMenu()
    {
        this._uiManager.GoToMainMenu(this._nextLevel);
    }

    public void Victory()
    {
        this._uiManager.GoToVictoryDefeatMenu(true, this._nbJump, this._nbDoubleJump, this._nbTripleJump, this._nbJelly, this._nbRings, this._nbTouchedRing, this._nbRingComboMax);
        this._levelManager.EndLevel();
        this._nextLevel++;
        this._nextLevelLimit = this._levelMaxLength + (this._incrementLevelMaxLength * this._nextLevel);
        SaveLevel();
        SetLevel();
        PauseGame();
        ResetStats();
    }

    public void Defeat()
    {
        this._uiManager.GoToVictoryDefeatMenu(false, this._nbJump, this._nbDoubleJump, this._nbTripleJump, this._nbJelly, this._nbRings, this._nbTouchedRing, this._nbRingComboMax);
        this._levelManager.EndLevel();
        SetLevel();
        PauseGame();
        ResetStats();
    }

    public void ReturnToMainMenu()
    {
        this._uiManager.GoToMainMenu(this._nextLevel);
        PauseGame();
    }
}