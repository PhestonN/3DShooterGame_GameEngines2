using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Transform lastCheckpoint;
    public CheckpointManager checkpointManager;
    public AudioSource checkpointSound;
    


    void OnTriggerEnter(Collider other)
    {
        // Eğer çarpışma gerçekleşen obje 'Checkpoint' tag'ine sahipse
        if (other.CompareTag("Checkpoint") )
        {
            lastCheckpoint = other.transform; // Yeni checkpoint'i kaydet
            Debug.Log("Checkpoint alındı!"); // Debug amacıyla konsola mesaj yazdır
            
            if (checkpointSound != null)
            {
                checkpointSound.Play();
            }
        }
        
        
        
    }
    public void ReturnToLastCheckpoint()
    {
        // Oyuncuyu son checkpoint pozisyonuna yerleştir
        transform.position = lastCheckpoint.position;
        Debug.Log("Returned to last checkpoint!");
    }
    void Die()
    {
        // Ölüm durumunda, son checkpoint'e geri dön
        checkpointManager.ReturnToLastCheckpoint();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışma olduğunda collision'ın etkileşime geçtiği objenin tag'i 'Enemy' ise
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die(); // Ölüm fonksiyonunu çağır
        }
    }

   
}