using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Sahne ge�i�leri i�in gerekli

public class OyunYonetici : MonoBehaviour
{
    public int skor = 0; // Ba�lang�� skoru
    public Text skorText; // Skoru g�sterecek UI Text
    public string anaBolumSahneAdi = "AnaMenu"; // Ana b�l�m�n sahne ad�

    void Start()
    {
        UpdateSkorText(); // Oyunun ba��nda skoru g�ster
    }

    public void SkorEkle(int value)
    {
        skor += value; // Skoru art�r
        UpdateSkorText(); // Skor g�ncelle

        // Skor 100'e ula�t���nda ana b�l�me d�n
        if (skor >= 100)
        {
            AnaBolumeDon();
        }
    }

    void UpdateSkorText()
    {
        if (skorText != null)
        {
            skorText.text = "Skor: " + skor; // UI'da skoru g�ncelle
        }
    }

    void AnaBolumeDon()
    {
        // Ana b�l�m sahnesine ge�i� yap
        SceneManager.LoadScene(anaBolumSahneAdi);
    }
}
