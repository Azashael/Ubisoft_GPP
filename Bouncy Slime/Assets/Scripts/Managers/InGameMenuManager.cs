using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuManager : MonoBehaviour
{
    [Header("Score zone")]
    [SerializeField]
    private Text _rightPlayerScore;
    [SerializeField]
    private Text _leftLevelScore;
    [SerializeField]
    private Slider _slideScore;

    public void UpdatePoints(int pts)
    {
        this._rightPlayerScore.text = pts.ToString();
        this._slideScore.value = pts;
    }

    public void SetObjective(int objective)
    {
        this._slideScore.maxValue = objective;
        this._slideScore.minValue = 0;
    }

    private float timer, refresh, avgFramerate;
    string display = "{0} FPS";
    [SerializeField]
    private Text _fpsText;


    private void Update()
    {
        //Change smoothDeltaTime to deltaTime or fixedDeltaTime to see the difference
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        _fpsText.text = string.Format(display, avgFramerate.ToString());
    }
}
