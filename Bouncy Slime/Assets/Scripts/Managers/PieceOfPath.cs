/**
 * Rochelle Charline
 * Novembre 2021 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOfPath : MonoBehaviour
{
    [Header("Attributs")]
    [SerializeField]
    private int _jumpCount;
    [SerializeField]
    private int _length;

    private bool _alreadyUsed;

    public int JumpCount { get => _jumpCount; }
    public int Length { get => _length; }
    public bool AlreadyUsed { get => _alreadyUsed; set => _alreadyUsed = value; }
}
