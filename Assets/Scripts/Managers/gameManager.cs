using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public static gameManager instance;

    public enum gameState{
        Start,
        Pause,
        End
    }

    public gameState _gameState;

    void Awake () {
        instance = this;
    }

    void Start () {
        _gameState = gameState.Start;
    }

    void Update () {
        
    }

    
}