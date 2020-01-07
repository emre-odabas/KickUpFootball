using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeControl : MonoBehaviour {
    public static timeControl instance;

    public int startTimeSec = 59;

    //Properties
    public int time { get; set; }
    public float timeStep { get; set; }

    void Awake () {
        instance = this;
    }

    void Start () {
        time = startTimeSec;
        //timeStep = 1;
        StartCoroutine ("timeCounter");
    }

    IEnumerator timeCounter () {
        for (int i = 0; i < startTimeSec; i++) {
            yield return new WaitForSeconds (timeStep);
            time--;
        }
    }

    void Update () {

    }
}