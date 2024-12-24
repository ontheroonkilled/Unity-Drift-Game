using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuKontrol : MonoBehaviour
{
    // Ayarlar Panelini ba�lamak i�in
    public GameObject ayarlarPaneli;

    // Oyna Butonu: B�l�m Se�im sahnesine ge�i�
    public void Oyna()
    {
        SceneManager.LoadScene("BolumSecim");
    }

    // Ayarlar Butonu: Ayarlar Panelini a�ar
    public void Ayarlar()
    {
        if (ayarlarPaneli != null)
        {
            ayarlarPaneli.SetActive(true);
        }
        else
        {
            Debug.LogError("Ayarlar Paneli atanmam��!");
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

    // ��k�� Butonu: Oyunu kapat�r
    public void Cikis()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Edit�rde testi durdurur
#else
        Application.Quit(); // Oyunu kapat�r
#endif
        Debug.Log("Oyun Kapat�ld�");
    }

    // Escape tu�u ile ayarlar� kapatma (iste�e ba�l�)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ayarlarPaneli.activeSelf)
        {
            AyarKapat();
        }
    }
}
