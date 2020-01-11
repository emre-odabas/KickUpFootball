using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeControl : MonoBehaviour {
    public static timeControl instance;

    public int startTimeSec = 59; //başlangıç saniyesi

    //Özellikler
    public int time { get; set; } //kalan zaman
    public float timeDuration { get; set; } = 1f; //zaman akış hızı
    public int timeStep { get; set; } = 1; //zaman artış basamağı

    void Awake () {
        instance = this;
    }

    void Start () {
        time = startTimeSec;      
    }

    void FixedUpdate () {

        if (time <= 0) {
            Debug.Log ("Süre doldu!");
            gameManager.instance.gameEnd ();
        }
    }

    public void startTimeCounter(){
        StartCoroutine("timeCounter");
    }

    public void stopTimeCounter(){
        StopCoroutine("timeCounter");
    }

    private IEnumerator timeCounter () {

        if (gameManager.instance.gameState == gameManager.GameState.Start) {
            for (int i = 0; i < startTimeSec; i++) {
                yield return new WaitForSeconds (timeDuration);
                time -= timeStep;
            }
        } 
    }
}