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

    [SerializeField]
    private GameState _gameState; //inspector de oyun durumunu görmek için

    //Özellikler
    public GameState gameState { get; set; } = GameState.Wait;

    void Awake () {
        instance = this;
    }

    void Start () {
        //gameState = GameState.Start;

        //_gameState = GameState.Wait;
        //Debug.Log(_gameState);
    }

    void FixedUpdate () {
        _gameState = gameState;
    }

    public void gameEnd () {
        gameState = GameState.End;
    }

}