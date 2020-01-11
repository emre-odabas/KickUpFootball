using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class destroyTimer : MonoBehaviour {
    public float destroyTime = 1f;
    public bool isParticle = true;
    public GameObject refDestroyParticle;

    void Start () {
        if (!isParticle) {
            StartCoroutine ("IEWithEffectDestroyer");
        } else {
            Destroy (gameObject, destroyTime);
        }

    }

    private IEnumerator IEWithEffectDestroyer () {
        yield return new WaitForSeconds (destroyTime);
        transform.DOScale (Vector2.zero, 1);
        yield return new WaitForSeconds (1);
        Instantiate (refDestroyParticle, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds (0.5f);
        Destroy (gameObject);
    }
}