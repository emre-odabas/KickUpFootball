using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour {

    public static UIControl instance;

    public int boardPadLeft = 2;

    //Texts
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighscore;

    void Awake () {
        instance = this;

    }

    void Start () {
        
    }

    void Update () {

    }

    void FixedUpdate () {
        textTime.text = timeControl.instance.time.ToString ();
        textScore.text = scoreManeger.instance.score.ToString().PadLeft(boardPadLeft,'0');
    }

}