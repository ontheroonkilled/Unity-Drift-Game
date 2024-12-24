using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class Zamanlayıcı : MonoBehaviour
{
    public float zaman = 30f;
    public Text ZamanText;

    void Update()
    {
        if (zaman > 0)
        {
            zaman -= Time.deltaTime;
            ZamanText.text = "Süre: " + Mathf.CeilToInt(zaman);
        }
        else
        {
            zaman = 0;
            ZamanText.text = "Oyun Bitti!";
            Time.timeScale = 0; // Oyun zamanını durdur
            StartCoroutine(BolumSecimSayfasinaDon()); // Coroutine başlat
        }
    }

    IEnumerator BolumSecimSayfasinaDon()
    {
        yield return new WaitForSecondsRealtime(5f); // 5 saniye bekle (Realtime, Time.timeScale = 0 olsa bile çalışır)
        Time.timeScale = 1; // Zamanı tekrar başlat
        SceneManager.LoadScene("BolumSecim"); // Bölüm seçme sahnesine dön
    }
}
