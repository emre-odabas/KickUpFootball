using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeControl : MonoBehaviour {
    public static timeControl instance;

    public int startTimeSec = 59; //başlangıç saniyesi

    //Özellikler
    public int time { get; set; } //kalan zaman
    public float timeDuration { get; set; } //zaman akış hızı
    public int timeStep { get; set; } //zaman artış basamağı

    void Awake () {
        instance = this;
    }

    void Start () {
        time = startTimeSec;
        timeDuration = 1;
        timeStep = 1;
        StartCoroutine ("timeCounter");
    }

    IEnumerator timeCounter () {
        for (int i = 0; i < startTimeSec; i++) {
            yield return new WaitForSeconds (timeDuration);
            time -= timeStep;
            if (time <= 10)
                UIControl.instance.textTime.color = Color.red;

        }
    }

    void FixedUpdate () {
        if (time == 0) {
            Debug.Log ("Süre doldu!");
        }
    }
}