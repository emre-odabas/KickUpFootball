using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public static gameManager instance;

    public enum GameState {
        Wait,
        Start,
        Pause,
        End
    }

    [Header ("OYUN DURUMLARI")]
    [SerializeField]
    private GameState _gameState; //inspector de oyun durumunu görmek için

    [Header ("REFERANSLAR")]
    public GameObject refSpawnParticle;

    //Özellikler
    public GameState gameState { get; set; } = GameState.Wait;

    void Awake () {
        instance = this;

    }

    void Start () {

    }

    void Update () {

    }

    void FixedUpdate () {
        _gameState = gameState;
    }

    public void gameEnd () {
        gameState = GameState.End;
    }

    public void spawnSkill () {
        StartCoroutine ("IESpawnSkill");
    }

     IEnumerator IESpawnSkill () {
        Debug.Log ("spawnskill aktif");
        //rndSkill
        Vector2 camPos = Camera.main.ScreenToWorldPoint (Vector2.zero);

        while (true) {
            if (gameState == GameState.Start) {
                yield return new WaitForSeconds (5);
                float rndX = Random.Range (-camPos.x - 1, camPos.x + 1);
                float rndY = Random.Range (-camPos.y - 5, camPos.y + 1);
                GameObject particle = Instantiate (refSpawnParticle, new Vector2 (rndX, rndY), Quaternion.identity);
                Debug.Log ("skill spawn oldu");
            }
        }
    }

}