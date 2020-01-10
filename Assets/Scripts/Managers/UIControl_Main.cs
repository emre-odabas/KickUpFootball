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
        btnPlayImage.DOAnchorPosX (-400, UIAnimationSpeed);
        btnPlayImage.DOLocalRotate (new Vector3 (0, 0, 180), UIAnimationSpeed);
        btnPlayImage.DOScale (new Vector2 (20, 20), UIAnimationSpeed);
        StartCoroutine ("playGameCounter");
    }
    public void btnMainQuitGame () {
        Application.Quit ();
    }

    IEnumerator playGameCounter () {
        yield return new WaitForSeconds (UIAnimationSpeed);
        SceneManager.LoadScene ("Level");
    }
}