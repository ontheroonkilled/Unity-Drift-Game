using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObje : MonoBehaviour
{
    public int skorDegeri = 10; // Her obje için eklenecek skor deðeri

    private void OnTriggerEnter(Collider other)
    {
        // Objeye temas eden þey "Player" tag'ine sahipse
        if (other.CompareTag("Player"))
        {
            // Skoru artýr ve objeyi yok et
            FindObjectOfType<OyunYonetici>().SkorEkle(skorDegeri);
            Destroy(gameObject);
        }
    }
}
