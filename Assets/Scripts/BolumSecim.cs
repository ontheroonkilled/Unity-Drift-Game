using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolumSecim : MonoBehaviour
{

        public void BolumYukle(string bolumAdi)
        {
            SceneManager.LoadScene(bolumAdi);
        }

    public void AnaSayfayaDon()
    {
        SceneManager.LoadScene("AnaMenu"); 
    }

}
