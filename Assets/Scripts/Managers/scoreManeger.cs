using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManeger : MonoBehaviour {

    public static scoreManeger instance;

    //Özellikler
    public int score { get; set; } = 0; //anlık skor
    public int highscore { get; set; } //anlık highscore
    public int scoreStep { get; set; } = 1; //skor artış saısı
    public bool touchDownWallReset { get; set; } = true; //zemine dokanınca sıfırla yada sıfırlama ayarı

    void Awake () {
        instance = this;
    }

    void Start () {
        highscore = PlayerPrefs.GetInt ("Highscore");
    }

    public void setScore () {
        score += scoreStep;

        if (score > highscore) {
            highscore = score;
            PlayerPrefs.SetInt ("Highscore", highscore);
        }
    }

    public void resetScore () {
        if (touchDownWallReset) {
            score = 0;
        }

    }

}