using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObje : MonoBehaviour
{
    public int skorDegeri = 10; // Her obje i�in eklenecek skor de�eri

    private void OnTriggerEnter(Collider other)
    {
        // Objeye temas eden �ey "Player" tag'ine sahipse
        if (other.CompareTag("Player"))
        {
            // Skoru art�r ve objeyi yok et
            FindObjectOfType<OyunYonetici>().SkorEkle(skorDegeri);
            Destroy(gameObject);
        }
    }
}
