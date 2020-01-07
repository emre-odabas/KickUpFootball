using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public static gameManager instance;

    private scoreManager _scoreManager;

    void Awake () {
        instance = this;

    }

    void Start () {
        _scoreManager = new scoreManager ();
    }

    void Update () {
        if (timeControl.instance.time == 0) {
            Debug.Log ("Süre doldu!");
        }
    }

    public void setScore () {
        _scoreManager.score += _scoreManager.scoreStep;
        UIControl.instance.textScore.text = _scoreManager.score.ToString ();
    }

    public void resetScore () {
        _scoreManager.score = 0;
        UIControl.instance.textScore.text = _scoreManager.score.ToString ();
    }
}