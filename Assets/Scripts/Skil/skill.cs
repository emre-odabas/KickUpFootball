
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Skill Item")]
public class skill : ScriptableObject
{  
    public Sprite sprite; // resmi
    public float duration; // kaç saniye ekranda kalacağı
    public string propertyTag; // Özellik etiketine göre topun bu tag a sahip objeye değince olacak olan işlemler için
}