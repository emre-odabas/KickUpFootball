using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeControl : MonoBehaviour {
    public static timeControl instance;

    public int startTimeSec = 59;

    //Properties
    public int time { get; set; }
    public float timeDuration { get; set; }
    public int timeStep { get; set; }

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

    void Update () {

    }
}