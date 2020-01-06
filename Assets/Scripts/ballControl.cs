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

        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        Vector2 touchpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        Vector2 direction = (Vector2) gameObject.transform.position - touchpos;

        if (direction.y < 0 || direction.y < 0.7f) {
            direction.y = 0.7f;
        }
        Debug.Log (direction); //x: 0.7 / -0.7   y: 0.7 / -0.7

        rb2d.AddForce (direction * pushForce);

    }
    void OnCollisionEnter2D (Collision2D other) {
        //Push Back
        /* if (other.gameObject.tag == "rightWall") {
             Debug.Log ("pushLeft");
             rb.AddForce (Vector2.left * pushForce, ForceMode2D.Impulse);
         } else if (other.gameObject.tag == "leftWall") {
             Debug.Log ("pushRight");
             rb.AddForce (Vector2.right * pushForce, ForceMode2D.Impulse);
         } else if (other.gameObject.tag == "downWall") {
             Debug.Log ("pushDown");
             rb.AddForce (Vector2.up * pushForce, ForceMode2D.Impulse);
         }*/

    }
}