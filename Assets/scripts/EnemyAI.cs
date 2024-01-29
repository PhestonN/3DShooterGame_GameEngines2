using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Transform player; // Oyuncu nesnesi
    public float moveSpeed = 3f; // Hareket hızı
    public float followRange = 5f; // Takip menzili

    bool isFollowing = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Oyuncu takip menziline girdiğinde takip etmeye başla
        if (distanceToPlayer <= followRange)
        {
            isFollowing = true;
        }

        // Takip etme durumu aktifse, oyuncuya doğru hareket et
        if (isFollowing)
        {
            transform.LookAt(player.position);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
