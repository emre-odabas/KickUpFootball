using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticle : MonoBehaviour {
    public float destroyTime = 1f;
    void Start () {
        Destroy (gameObject, destroyTime);
    }

    void Update () {

    }
}