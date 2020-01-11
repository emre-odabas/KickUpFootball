using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ballControl : MonoBehaviour {

    public static ballControl instance;

    public float pushForce = 1000;

    //Özellikler
    public Rigidbody2D rb2d { get; set; }

    void Awake () {
        instance = this;
    }

    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D> ();
        rb2d.simulated = false;
    }

    void Update () {

        /*if (gameManager.instance.gameState == gameManager.GameState.Start)
            rb2d.simulated = true;
        else
            rb2d.simulated = false;*/
    }

    void OnMouseDown () {
        if (gameManager.instance.gameState == gameManager.GameState.Start) {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Vector2 touchpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            Vector2 direction = (Vector2) gameObject.transform.position - touchpos;

            //direction x: 0.7 / -0.7   
            //direction y: 0.7 / -0.7

            if (direction.y < 0 || direction.y < 0.7f) {
                direction.y = 0.7f;
            }
            rb2d.AddForce (direction * pushForce);
            scoreManeger.instance.setScore ();
        }
    }
    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "downWall") {
            scoreManeger.instance.resetScore ();
        }
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "ballFast") {
            Debug.Log ("ballFast");
        } else if (col.gameObject.tag == "ballFreeze") {
            Debug.Log ("ballFreeze");
        } else if (col.gameObject.tag == "ballMax") {
            gameObject.transform.DOScale (2, 1);
        } else if (col.gameObject.tag == "ballMin") {
            gameObject.transform.DOScale (0.5f, 1);
        } else if (col.gameObject.tag == "controlReverse") {
            Debug.Log ("controlReverse");
        } else if (col.gameObject.tag == "time+10") {
            timeControl.instance.time += 10;
        } else if (col.gameObject.tag == "time-10") {
            timeControl.instance.time -= 10;
        } else if (col.gameObject.tag == "timeFast") {
            timeControl.instance.timeDuration = 0.5f;
        } else if (col.gameObject.tag == "timeFreeze") {
            timeControl.instance.timeStep = 0;
        } else if (col.gameObject.tag == "timeSlow") {
            timeControl.instance.timeDuration = 2f;
        }
    }

}