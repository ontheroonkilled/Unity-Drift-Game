using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastgeleKüp : MonoBehaviour
{
    public GameObject kupPrefab; 
    public Transform yuzeyTransform; 
    public int kupSayisi = 20; 
    public float yukseklikOffset = 0.5f; 
    public float minimumMesafe = 1.0f; 

    private List<Vector3> kullanilanPozisyonlar = new List<Vector3>();

    void Start()
    {
        KupleriRastgeleDagit();
    }

    void KupleriRastgeleDagit()
    {
        Renderer yuzeyRenderer = yuzeyTransform.GetComponent<Renderer>();
        Vector3 yuzeyBoyutu = yuzeyRenderer.bounds.size;
        Vector3 yuzeyPozisyonu = yuzeyTransform.position;

        int olusturulanKupSayisi = 0; 

        while (olusturulanKupSayisi < kupSayisi)
        {
            float rastgeleX = Random.Range(yuzeyPozisyonu.x - yuzeyBoyutu.x / 2, yuzeyPozisyonu.x + yuzeyBoyutu.x / 2);
            float rastgeleZ = Random.Range(yuzeyPozisyonu.z - yuzeyBoyutu.z / 2, yuzeyPozisyonu.z + yuzeyBoyutu.z / 2);
            Vector3 rastgelePozisyon = new Vector3(rastgeleX, yuzeyPozisyonu.y + yukseklikOffset, rastgeleZ);

            if (PozisyonUygunMu(rastgelePozisyon))
            {
                Instantiate(kupPrefab, rastgelePozisyon, Quaternion.identity);
                kullanilanPozisyonlar.Add(rastgelePozisyon); 
                olusturulanKupSayisi++;
            }
        }
    }

    bool PozisyonUygunMu(Vector3 yeniPozisyon)
    {
        foreach (Vector3 kullanilanPozisyon in kullanilanPozisyonlar)
        {
            if (Vector3.Distance(yeniPozisyon, kullanilanPozisyon) < minimumMesafe)
            {
                return false; 
            }
        }
        return true; 
    }
}
