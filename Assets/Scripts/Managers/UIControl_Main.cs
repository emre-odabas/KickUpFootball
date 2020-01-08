using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl_Main : MonoBehaviour {
    public float UIAnimationSpeed = 1f;

    [Header ("Butonlar")]
    public RectTransform btnPlayImage;

    void Start () {

    }

    public void btnMainPlayGame () {
        btnPlayImage.DOScale (new Vector2 (20, 20), UIAnimationSpeed);
        btnPlayImage.DOLocalRotate (new Vector3 (0, 0, 180), UIAnimationSpeed);
        btnPlayImage.DOAnchorPosX (-400, UIAnimationSpeed);
        StartCoroutine ("playGameCounter");
    }
    public void btnMainQuitGame () {
        Application.Quit ();
    }

    IEnumerator playGameCounter () {
        for (int i = 0; i < UIAnimationSpeed; i++) {
            yield return new WaitForSeconds (1);
            SceneManager.LoadScene ("Level");
        }
    }
}