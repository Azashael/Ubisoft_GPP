/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Test")]
    [SerializeField]
    private bool _test;
    [SerializeField]
    private PieceOfPath _prefabTest;
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
    private PieceOfPath[] _easyPrefabs;

    private List<PieceOfPath> _currentPath;
    private int _maxLengthJump;
    private int _lengthJumpPath = 0;
    private bool _generate = false;
    private bool _move = false;
    private int _lengthCurrent = 0;

    private void FixedUpdate()
    {
        if (this._move)
        { 
            MoveTiles(); 
        }

        RemoveFirst();

        GenerateNext();
    }

    private void MoveTiles()
    {
        foreach (PieceOfPath segment in this._currentPath)
        {
            segment.transform.Translate((-Vector3.forward * Time.deltaTime) * this._speedScroll);
        }
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
            if (this._lengthJumpPath < this._maxLengthJump)
            {
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
        if(this._lengthCurrent < this._minLengthCurrent)
        {
            GameObject newTile = Instantiate(this._prefabTest.gameObject, this._pathContainer.transform);
            this._lengthCurrent += this._prefabTest.Length;
            newTile.transform.position = this._currentPath[this._currentPath.Count - 1].transform.position + new Vector3 (0, 0, this._currentPath[this._currentPath.Count - 1].Length);
            PieceOfPath popNewTile = newTile.GetComponent<PieceOfPath>();
            this._lengthJumpPath += popNewTile.JumpCount;
            this._currentPath.Add(popNewTile);
        }
    }

    private void GenerateEnd()
    {
        GameObject newTile = Instantiate(this._endPath.gameObject, this._pathContainer.transform);
        newTile.transform.position = this._currentPath[this._currentPath.Count - 1].transform.position + new Vector3(0, 0, this._currentPath[this._currentPath.Count - 1].Length);
        PieceOfPath popNewTile = newTile.GetComponent<PieceOfPath>();
        this._lengthJumpPath += popNewTile.JumpCount;
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
        this._lengthJumpPath = 0;
        this._maxLengthJump = 0;
        this._lengthCurrent = 0;
    }

    public void StartPath()
    {
        GenerateStart();
    }
}
