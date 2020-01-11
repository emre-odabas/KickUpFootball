using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

    //rasgele oluşturulan particle ve objeler için rasgele min-max aralığı
    public float rndMinTime = 5;
    public float rndMaxTime = 20;
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
        float skillDuration = Random.Range (rndMinTime, rndMaxTime);
        Vector2 camPos = Camera.main.ScreenToWorldPoint (Vector2.zero);
        while (true) {
            yield return new WaitForSeconds (skillDuration);
            float rndX = Random.Range (-camPos.x - 1, camPos.x + 1);
            float rndY = Random.Range (-camPos.y - 5, camPos.y + 1);
            GameObject particle = Instantiate (refSpawnParticle, new Vector2 (rndX, rndY), Quaternion.identity);
            skillDuration = Random.Range (rndMinTime, rndMaxTime);
            //Debug.Log ("Skill spawn oluyor. Bir sonraki skill " + skillDuration + " saniye sonra spawn olacak.");

            StartCoroutine ("IESpawnSkill", new Vector2 (rndX, rndY));
        }
    }

    private IEnumerator IESpawnSkill (Vector2 skillPos) {
        yield return new WaitForSeconds (3);
        int rndSkillIndex = Random.Range (0, skills.Length);
        GameObject skill = Instantiate (refSkill, new Vector2 (skillPos.x, skillPos.y), Quaternion.identity);
        skill.transform.DOScale (new Vector2 (0.5f, 0.5f), 1);
        skill.transform.GetComponent<SpriteRenderer> ().sprite = skills[rndSkillIndex].sprite;
        skill.transform.GetComponent<destroyTimer> ().destroyTime = skills[rndSkillIndex].duration;
        skill.transform.GetComponent<destroyTimer> ().isParticle = false;
        skill.gameObject.tag = skills[rndSkillIndex].skillTag;
    }

}