using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public int maxAmmo = 10; // Maksimum mermi sayısı
    private float currentAmmo; // Şu anki mermi sayısı
    public float reloadTime = 1f; // Reload süresi
    private bool isReloading = false; // Reload durumu
    public Image bulletAmount;
    public AudioSource shootingSound;
    public AudioSource reloadSound;



    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Shoot()
    {
        if (isReloading || Time.timeScale == 0) return; // Eğer reload durumundaysa ateş etme

        if (currentAmmo > 0)
        {
            // Mermi at
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed;
            }
            else
            {
                Debug.LogError("Rigidbody missing on the bullet prefab!");
            }
            if (shootingSound != null)
            {
                shootingSound.Play();
            }
            currentAmmo--; // Mermi sayısını bir azalt
        }
        else
        {
            StartCoroutine(Reload()); // Eğer mermi kalmadıysa reload işlemini başlat
        }
    }

    IEnumerator Reload()
    {
        if (reloadSound != null)
        {
            reloadSound.Play(); // Reload sesini çal
        }
        isReloading = true; // Reload durumunu başlat
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime); // Belirtilen süre kadar bekle

        currentAmmo = maxAmmo; // Mermi sayısını yeniden maksimuma ayarla
        isReloading = false; // Reload durumunu kapat
        
    }

    void Update()
    {

     
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            
        }  
        bulletAmount.fillAmount = currentAmmo / 10;
        
    }
    

}