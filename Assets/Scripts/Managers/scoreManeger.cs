using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManeger : MonoBehaviour {

    public static scoreManeger instance;

    //Özellikler
    public int score { get; set; } = 0; //anlık skor
    public int scoreStep { get; set; } = 1; //skor artış saısı
    public bool touchDownWallReset { get; set; } = true; //zemine dokanınca sıfırla yada sıfırlama ayarı

    void Awake () {
        instance = this;
    }

    public void setScore () {
        score += scoreStep;
    }

    public void resetScore () {
        if (touchDownWallReset) {
            score = 0;
        }

    }

}