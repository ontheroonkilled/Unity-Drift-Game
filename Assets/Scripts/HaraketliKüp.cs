using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaraketliKüp : MonoBehaviour
{
    public float kacisHizi = 5f;            // Küplerin kaçış hızı
    public float kacisMesafesi = 2f;        // Kaçışın başlayacağı maksimum mesafe (kontrol edilebilir)
    private Transform oyuncu;               // Oyuncu Transform'u
    private Bounds platformSinirlari;       // Platform sınırları
    private Vector3 kacisYonu;              // Oyuncudan kaçış yönü

    void Start()
    {
        // Oyuncuyu "Player" etiketi ile bul
        GameObject oyuncuObjesi = GameObject.FindGameObjectWithTag("Player");
        if (oyuncuObjesi != null)
        {
            oyuncu = oyuncuObjesi.transform;
        }
        else
        {
            Debug.LogError("Oyuncu bulunamadı! 'Player' etiketi doğru ayarlandı mı?");
        }

        // Platformun sınırlarını bul
        GameObject platform = GameObject.Find("Yer");
        if (platform != null)
        {
            Collider platformCollider = platform.GetComponent<Collider>();
            if (platformCollider != null)
            {
                platformSinirlari = platformCollider.bounds;
            }
            else
            {
                Debug.LogError("Platform objesine bir Collider eklenmeli!");
            }
        }
        else
        {
            Debug.LogError("Platform objesi bulunamadı! Adını kontrol edin.");
        }

        // Rastgele başlangıç yönü
        kacisYonu = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        if (oyuncu == null) return;

        // Oyuncu ile küp arasındaki mesafeyi hesapla
        float mesafe = Vector3.Distance(transform.position, oyuncu.position);

        // Eğer mesafe kaçış mesafesinden küçükse kaçış davranışı başlasın
        if (mesafe <= kacisMesafesi)
        {
            // Oyuncudan kaçış yönünü hesapla (sadece X-Z ekseninde)
            Vector3 oyuncuPozisyonu = new Vector3(oyuncu.position.x, transform.position.y, oyuncu.position.z);
            kacisYonu = (transform.position - oyuncuPozisyonu).normalized;

            // Yeni pozisyonu hesapla
            Vector3 yeniPozisyon = transform.position + kacisYonu * kacisHizi * Time.deltaTime;

            // Y ekseni sabit tut, sadece X ve Z ekseninde hareket et
            yeniPozisyon.y = transform.position.y;

            // Yeni pozisyonun platform sınırları içinde kalmasını sağla
            yeniPozisyon.x = Mathf.Clamp(yeniPozisyon.x, platformSinirlari.min.x, platformSinirlari.max.x);
            yeniPozisyon.z = Mathf.Clamp(yeniPozisyon.z, platformSinirlari.min.z, platformSinirlari.max.z);

            // Eğer köşeye takıldıysa yönü rastgele değiştir
            if ((yeniPozisyon.x <= platformSinirlari.min.x || yeniPozisyon.x >= platformSinirlari.max.x) ||
                (yeniPozisyon.z <= platformSinirlari.min.z || yeniPozisyon.z >= platformSinirlari.max.z))
            {
                kacisYonu = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            }

            // Pozisyonu güncelle
            transform.position = yeniPozisyon;
        }
    }
}
