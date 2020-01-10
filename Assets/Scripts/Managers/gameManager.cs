using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public static gameManager instance;

    //Oyun durumları
    public enum GameState {
        Wait,
        Start,
        Pause,
        End
    }

    [SerializeField]
    private GameState _gameState; //inspector de oyun durumunu görmek için

    //Rasgele özellik sınır alanı
    public float x;
    public float y;

    //Özellikler
    public GameState gameState { get; set; } = GameState.Wait;

    void Awake () {
        instance = this;
    }

    void OnDrawGizmos () {
        // Draw a yellow sphere at the transform's position
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        //float horizontalMin = -halfWidth;
        //float horizontalMax = halfWidth;
        Vector2 campos = Camera.main.ScreenToWorldPoint (Vector2.zero);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube (new Vector2 (0, -1.5f), new Vector2 (campos.x * x, campos.y * y));
        //Gizmos.DrawWireCube (new Vector2 (0, 0), new Vector2 (halfWidth + 8, halfHeight + 1));

        //Vector3 randomPosition = Camera.main.ScreenToWorldPoint(originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax)));
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