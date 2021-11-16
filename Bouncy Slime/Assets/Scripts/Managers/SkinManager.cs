using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField]
    private Button[] _buttonsSkin;

    public void OnChange(int s)
    {
        foreach (Button btn in this._buttonsSkin)
        {
            btn.interactable = true;
        }
        this._buttonsSkin[s].interactable = false;
    }

    public void Start()
    {
        OnChange(GameManager.instance.SkinPlayer);
    }
}
