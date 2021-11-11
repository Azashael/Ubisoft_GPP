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
    private uint _minTiles;
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
    private int _maxLength;

    void Start()
    {
        _currentPath = new List<PieceOfPath>();
        GameObject startTile = Instantiate(this._startPath.gameObject, this._pathContainer.transform);
        startTile.transform.position = new Vector3(0, 0, -.5f);
        this._currentPath.Add(startTile.GetComponent<PieceOfPath>());
        GeneratePath();
    }

    private void Update()
    {
        foreach(PieceOfPath segment in this._currentPath)
        {
            segment.transform.Translate((-Vector3.forward * Time.deltaTime) * this._speedScroll);
        }

        if (this._currentPath[0].transform.position.z + this._currentPath[0].Length < this._limitZ)
        {
            Destroy(this._currentPath[0].gameObject);
            this._currentPath.RemoveAt(0);
        }

        GeneratePath();
    }

    void GeneratePath()
    {
        if(this._currentPath.Count < this._minTiles)
        {
            GameObject newTile = Instantiate(this._prefabTest.gameObject, this._pathContainer.transform);
            newTile.transform.position = this._currentPath[this._currentPath.Count - 1].transform.position + new Vector3 (0, 0, this._currentPath[this._currentPath.Count - 1].Length);
            this._currentPath.Add(newTile.GetComponent<PieceOfPath>());
        }
    }
}
