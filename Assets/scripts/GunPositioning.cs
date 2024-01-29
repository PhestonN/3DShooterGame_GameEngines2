using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPositioning : MonoBehaviour
{
    public Transform playerCamera; // Oyuncunun kamera transform'u
    public Vector3 offset; // Silahın kameradan ne kadar uzakta olacağı
   
    void LateUpdate()
    {
        // Silahın pozisyonunu ayarla
        transform.position = playerCamera.position + playerCamera.forward * offset.z +
                             playerCamera.right * offset.x + playerCamera.up * offset.y;
        
        // Silahın rotasyonunu kameranın rotasyonuna eşitle
        transform.rotation = Quaternion.Euler( -playerCamera.eulerAngles.x , playerCamera.eulerAngles.y + 180, 0f );
    }
}