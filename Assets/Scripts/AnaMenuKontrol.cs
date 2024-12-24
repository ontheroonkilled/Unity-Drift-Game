using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuKontrol : MonoBehaviour
{
    // Ayarlar Panelini baðlamak için
    public GameObject ayarlarPaneli;

    // Oyna Butonu: Bölüm Seçim sahnesine geçiþ
    public void Oyna()
    {
        SceneManager.LoadScene("BolumSecim");
    }

    // Ayarlar Butonu: Ayarlar Panelini açar
    public void Ayarlar()
    {
        if (ayarlarPaneli != null)
        {
            ayarlarPaneli.SetActive(true);
        }
        else
        {
            Debug.LogError("Ayarlar Paneli atanmamýþ!");
        }
    }

    // Ayarlar Panelini kapatma
    public void AyarKapat()
    {
        if (ayarlarPaneli != null)
        {
            ayarlarPaneli.SetActive(false);
        }
    }

    // Çýkýþ Butonu: Oyunu kapatýr
    public void Cikis()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Editörde testi durdurur
#else
        Application.Quit(); // Oyunu kapatýr
#endif
        Debug.Log("Oyun Kapatýldý");
    }

    // Escape tuþu ile ayarlarý kapatma (isteðe baðlý)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ayarlarPaneli.activeSelf)
        {
            AyarKapat();
        }
    }
}
