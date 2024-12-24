using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Sahne geçiþleri için gerekli

public class OyunYonetici : MonoBehaviour
{
    public int skor = 0; // Baþlangýç skoru
    public Text skorText; // Skoru gösterecek UI Text
    public string anaBolumSahneAdi = "AnaMenu"; // Ana bölümün sahne adý

    void Start()
    {
        UpdateSkorText(); // Oyunun baþýnda skoru göster
    }

    public void SkorEkle(int value)
    {
        skor += value; // Skoru artýr
        UpdateSkorText(); // Skor güncelle

        // Skor 100'e ulaþtýðýnda ana bölüme dön
        if (skor >= 100)
        {
            AnaBolumeDon();
        }
    }

    void UpdateSkorText()
    {
        if (skorText != null)
        {
            skorText.text = "Skor: " + skor; // UI'da skoru güncelle
        }
    }

    void AnaBolumeDon()
    {
        // Ana bölüm sahnesine geçiþ yap
        SceneManager.LoadScene(anaBolumSahneAdi);
    }
}
