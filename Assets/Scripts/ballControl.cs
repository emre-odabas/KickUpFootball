using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour {

    public float pushForce = 1000;
    private Rigidbody2D rb2d;
    
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D> ();
    }

    void Update () {

    }

    void OnMouseDown () {
        //Push back
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        Vector2 touchpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        Vector2 direction = (Vector2) gameObject.transform.position - touchpos;

        //direction x: 0.7 / -0.7   
        //direction y: 0.7 / -0.7

        if (direction.y < 0 || direction.y < 0.7f) {
            direction.y = 0.7f;
        }

        rb2d.AddForce (direction * pushForce);

        gameManager.instance.setScore ();
    }
    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "downWall") {
            gameManager.instance.resetScore ();
        }

    }
}