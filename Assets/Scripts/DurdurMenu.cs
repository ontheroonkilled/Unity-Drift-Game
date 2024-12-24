using UnityEngine;
using UnityEngine.SceneManagement;

public class DurdurMenu : MonoBehaviour 
{
    public bool OyunDurduMu = false;
    public GameObject durdurMenuUI;
    public GameObject ayarlarMenuUI;

    public void DevamEt()
    {
        durdurMenuUI.SetActive(false);
        ayarlarMenuUI.SetActive(false);
        Time.timeScale = 1f;
        OyunDurduMu = false;
    }

    public void Durdur()
    {
        durdurMenuUI.SetActive(true);
        Time.timeScale = 0f;
        OyunDurduMu = true;
    }

    public void AyarlarMenuAc()
    {
        durdurMenuUI.SetActive(false);
        ayarlarMenuUI.SetActive(true);
    }

    public void AyarlarMenuKapat()
    {
        ayarlarMenuUI.SetActive(false);
        durdurMenuUI.SetActive(true);
    }

    public void AnaMenuyeDon()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AnaMenu");
    }

    public void OyundanCik()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        Debug.Log("Oyundan çıkıldı!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OyunDurduMu)
            {
                DevamEt();
            }
            else
            {
                Durdur();
            }
        }
    }
}
