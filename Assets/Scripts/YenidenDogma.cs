using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YenidenDogma : MonoBehaviour
{
    private Vector3 BaslangicNoktasi;
    private Quaternion BaslangicRotasyonu;
    public float DüsmeEsik = -10f;    

    void Start()
    {
        BaslangicNoktasi = transform.position;
        BaslangicRotasyonu = transform.rotation;
    }

    void Update()
    {
        if (transform.position.y < DüsmeEsik)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = BaslangicNoktasi;
        transform.rotation = BaslangicRotasyonu;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
