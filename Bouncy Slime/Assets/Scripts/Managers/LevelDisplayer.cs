using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplayer : MonoBehaviour
{
    private int _level = 1;

    public int Level { get => _level; }

    public void SetLevel(int level)
    {
        this._level = level;
    }
}
