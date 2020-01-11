using UnityEngine;

public class skillProperty : MonoBehaviour
{
    public Sprite sprite { get; set; } // resmi
    public Vector2 location { get; set; } // ekrandaki konumu
    public float duration { get; set; } // kaç saniye ekranda kalacağı
    public string propertyTag { get; set; } // Özellik etiketine göre topun bu tag a sahip objeye değince olacak olan işlemler için
}
