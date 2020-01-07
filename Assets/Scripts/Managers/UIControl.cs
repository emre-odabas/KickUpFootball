using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour {

    public static UIControl instance;

    private scoreManager _scoreManager;

    //Texts
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighscore;

    void Awake () {
        instance = this;

    }

    void Start () {
        _scoreManager = new scoreManager ();
    }

    void Update () {

    }

    void FixedUpdate () {
        textTime.text = timeControl.instance.time.ToString ();
        //textScore.text = _scoreManager.score.ToString ();
    }

}