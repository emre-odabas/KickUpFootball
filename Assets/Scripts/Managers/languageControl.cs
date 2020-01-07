using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class languageControl : MonoBehaviour {
    public enum Language {
        Tr,
        En
    }
    public static languageControl instance;

    [SerializeField]
    private Language _currentLanguage;

    //UI elemanları
    public TextMeshProUGUI textTimeTitle;
    public TextMeshProUGUI textScoreTitle;
    public TextMeshProUGUI textHighscoreTitle;

    //Özellikler
    public Language currentLanguage { get; set; }

    void awake () {
        instance = this;
    }

    void Start () {

        if (_currentLanguage == Language.En) {
            setupLanguage (Language.En);
        } else if (_currentLanguage == Language.Tr) {
            setupLanguage (Language.Tr);
        }

        currentLanguage = _currentLanguage;
    }

    void Update () {

    }

    public void setupLanguage (Language _language) {

        switch (_language) {
            //EN
            case Language.En:
                //PlayerPrefs.SetString ("Language", "En");
                _currentLanguage = Language.En;
                 
                textTimeTitle.text = "Time";
                textScoreTitle.text = "Score";
                textHighscoreTitle.text = "Highscore";
                break;

                //TR
            case Language.Tr:
                //PlayerPrefs.SetString ("Language", "Tr");
                _currentLanguage = Language.Tr;
                 
                textTimeTitle.text = "Zaman";
                textScoreTitle.text = "Skor";
                textHighscoreTitle.text = "En Yüksek";
                break;
        }
    }
}