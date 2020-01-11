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
    public GameObject refSkill;

    public skill[] skills;

    //Özellikler
    public GameState gameState { get; set; } = GameState.Wait;

    void Awake () {
        instance = this;

    }

    void FixedUpdate () {
        _gameState = gameState;
    }

    public void gameEnd () {
        gameState = GameState.End;
        StopCoroutine ("IESpawnSkillParticle");
    }

    public void spawnSkill () {
        StartCoroutine ("IESpawnSkillParticle");
    }

    //skillden önce particle effect i verip ondan sonra skill i spawnlıyoruz
    private IEnumerator IESpawnSkillParticle () {
        float slillDuration = 5;
        Vector2 camPos = Camera.main.ScreenToWorldPoint (Vector2.zero);
        while (true) {
            yield return new WaitForSeconds (slillDuration);
            float rndX = Random.Range (-camPos.x - 1, camPos.x + 1);
            float rndY = Random.Range (-camPos.y - 5, camPos.y + 1);
            GameObject particle = Instantiate (refSpawnParticle, new Vector2 (rndX, rndY), Quaternion.identity);
            slillDuration = Random.Range (5, 15);
            Debug.Log ("Skill spawn oluyor. Bir sonraki skill " + slillDuration + " saniye sonra spawn olacak.");

            StartCoroutine ("IESpawnSkill", new Vector2 (rndX, rndY));
        }
    }

    private IEnumerator IESpawnSkill (Vector2 skillPos) {
        yield return new WaitForSeconds (3);
        GameObject itemObject = Instantiate (refSkill, new Vector2 (skillPos.x, skillPos.y), Quaternion.identity);
        itemObject.transform.GetComponent<SpriteRenderer> ().sprite = skills[0].sprite;
    }

}