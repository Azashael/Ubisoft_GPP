using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance { get { return s_Instance; } }
    static protected GameManager s_Instance;

    [Header("Managers")]
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private LevelManager _levelManager;

    void Start()
    {
        s_Instance = this;
    }

    void Update()
    {
        
    }

    public void UpdatePoints(int pts)
    {
        this._uiManager.UpdatePoints(pts);
    }
}
