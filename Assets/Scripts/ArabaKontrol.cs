using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabaKontrol : MonoBehaviour
{
    // Settings
    public float Hiz = 50;
    public float MaxHiz = 15;
    public float Suruklenme = 0.98f;
    public float Acý = 20;
    public float Cekis = 1;

    // Variables
    private Vector3 kuvvet;

    // Update is called once per frame
    void Update()
    {

        kuvvet += transform.forward * Hiz * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += kuvvet * Time.deltaTime;

        // Steering
        float DireksiyonGiris = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * DireksiyonGiris * kuvvet.magnitude * Acý * Time.deltaTime);

        // Drag and max speed limit
        kuvvet *= Suruklenme;
        kuvvet = Vector3.ClampMagnitude(kuvvet, MaxHiz);

        // Traction
        Debug.DrawRay(transform.position, kuvvet.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        kuvvet = Vector3.Lerp(kuvvet.normalized, transform.forward, Cekis * Time.deltaTime) * kuvvet.magnitude;
    }
}
