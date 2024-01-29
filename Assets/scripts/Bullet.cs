using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f; // Mermi hızı
    public float maxDistance = 100.0f; // Maksimum mesafe
    private Vector3 initialPosition; // Mermi başlangıç pozisyonu

    void Start()
    {
        initialPosition = transform.position; // Mermi başlangıç pozisyonunu sakla
    }

    void Update()
    {
        // Mermiyi ileri doğru hareket ettir
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Mermi başlangıç pozisyonundan belirtilen maksimum mesafeyi aştıysa mermiyi yok et
        if (Vector3.Distance(transform.position, initialPosition) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Çarpışan nesne bir düşman mı?
        if (other.CompareTag("Enemy"))
        {
            // Düşmanı yok et
            Destroy(other.gameObject);

            // Mermiyi yok et
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Mermi bir şeye çarptığında yok et
        Destroy(gameObject);
    }
}