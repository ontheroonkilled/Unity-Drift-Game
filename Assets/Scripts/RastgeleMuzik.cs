using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastgeleMuzik : MonoBehaviour
{
    public AudioClip[] muzikler;  
    private AudioSource MuzikKaynak;  
    private int oncekiMuzikIndex = -1; 

    private static RastgeleMuzik instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
            return;
        }
    }

    void Start()
    {
        MuzikKaynak = GetComponent<AudioSource>();
        if (MuzikKaynak == null)
        {
            MuzikKaynak = gameObject.AddComponent<AudioSource>();
        }

        MuzikKaynak.playOnAwake = false;
        MuzikKaynak.loop = false;

        PlayRastgeleMuzik();
    }

    void PlayRastgeleMuzik()
    {
        if (muzikler.Length > 0)
        {
            int rastgeleIndex;

            do
            {
                rastgeleIndex = Random.Range(0, muzikler.Length);
            } while (rastgeleIndex == oncekiMuzikIndex);

            oncekiMuzikIndex = rastgeleIndex;
            MuzikKaynak.clip = muzikler[rastgeleIndex];
            MuzikKaynak.Play();

            StartCoroutine(MuzikSonuBekle(MuzikKaynak.clip.length));
        }
    }

    IEnumerator MuzikSonuBekle(float sure)
    {
        yield return new WaitForSeconds(sure);
        PlayRastgeleMuzik();
    }
}
