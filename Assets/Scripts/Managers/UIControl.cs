using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour {
    public TextMeshProUGUI textTime;

    void Start () {

    }

    void Update () {

    }

    void FixedUpdate () {
        textTime.text = timeControl.instance.time.ToString ();
    }

}