/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float _speedScroll;
    [SerializeField]
    private uint _minLengthCurrent;
    [SerializeField]
    private int _limitZ;

    [Header("Contenant Path")]
    [SerializeField]
    private GameObject _pathContainer;

    [Header("Path Prefabs")]
    [SerializeField]
    private PieceOfPath _startPath;
    [SerializeField]
    private PieceOfPath _endPath;
    [SerializeField]
    private PieceOfPath[] _pathPrefabs;
    [SerializeField]
    private GameObject[] _skinPlayer;

    private List<PieceOfPath> _currentPath;
    private int _maxLengthJump;
    private bool _generate = false;
    private bool _move = false;
    private int _lengthCurrent = 0;
    private double _distanceTravelled = 0;

    private void FixedUpdate()
    {
        if (this._move)
        { 
            MoveTiles(); 
        }

        RemoveFirst();

        GenerateNext();
    }

    public void ApplySkin()
    {
        foreach(GameObject go in this._skinPlayer)
        {
            go.SetActive(false);
        }
        this._skinPlayer[GameManager.instance.SkinPlayer].SetActive(true);
    }

    private void MoveTiles()
    {
        Vector3 moves = (-Vector3.forward * Time.deltaTime) * this._speedScroll;
        foreach (PieceOfPath segment in this._currentPath)
        {
            segment.transform.Translate(moves);
        }
        this._distanceTravelled += (1 * Time.deltaTime * this._speedScroll) / 3;
        GameManager.instance.UpdatePoints(Convert.ToInt32(Math.Floor(this._distanceTravelled)));
    }

    public void StartMoving()
    {
        this._generate = true;
        this._move = true;
    }

    private void RemoveFirst()
    {
        if (this._currentPath[0].transform.position.z + this._currentPath[0].Length < this._limitZ)
        {
            this._lengthCurrent -= this._currentPath[0].Length;
            Destroy(this._currentPath[0].gameObject);
            this._currentPath.RemoveAt(0);
        }
    }

    private void GenerateStart()
    {
        _currentPath = new List<PieceOfPath>();
        GameObject startTile = Instantiate(this._startPath.gameObject, this._pathContainer.transform);
        this._lengthCurrent += this._startPath.Length;
        startTile.transform.position = new Vector3(0, 0, 0);
        this._currentPath.Add(startTile.GetComponent<PieceOfPath>());
        while (this._lengthCurrent < this._minLengthCurrent)
        {
            GeneratePath();
        }
    }

    private void GenerateNext()
    {
        if (this._generate)
        {
            if (GameManager.instance.GetPoints() < this._maxLengthJump)
            {
                if(this._lengthCurrent < this._minLengthCurrent)
                    GeneratePath();
            }
            else
            {
                this._generate = false;
                GenerateEnd();
            }
        }
    }

    private void GeneratePath()
    {
        PieceOfPath popPref = this._pathPrefabs[UnityEngine.Random.Range(0, this._pathPrefabs.Length)];
        GameObject newTile = Instantiate(popPref.gameObject, this._pathContainer.transform);
        this._lengthCurrent += popPref.Length;
        newTile.transform.position = this._currentPath[this._currentPath.Count - 1].transform.position + new Vector3 (0, 0, this._currentPath[this._currentPath.Count - 1].Length);
        PieceOfPath popNewTile = newTile.GetComponent<PieceOfPath>();
        this._currentPath.Add(popNewTile);
    }

    private void GenerateEnd()
    {
        GameObject newTile = Instantiate(this._endPath.gameObject, this._pathContainer.transform);
        newTile.transform.position = this._currentPath[this._currentPath.Count - 1].transform.position + new Vector3(0, 0, this._currentPath[this._currentPath.Count - 1].Length);
        PieceOfPath popNewTile = newTile.GetComponent<PieceOfPath>();
        this._currentPath.Add(popNewTile);
    }

    public void SetLevelLength(int length)
    {
        this._maxLengthJump = length;
    }

    public void EndLevel()
    {
        foreach(PieceOfPath p in this._currentPath)
        {
            Destroy(p.gameObject);
        }
        this._currentPath.Clear();
        this._generate = false;
        this._move = false;
        this._maxLengthJump = 0;
        this._lengthCurrent = 0;
        this._distanceTravelled = 0;
    }

    public void StartPath()
    {
        GenerateStart();
    }
}
