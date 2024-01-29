using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Fare hassasiyeti
    public Transform playerBody; // Oyuncu karakteri
    public float moveSpeed = 5f; // Kamera hareket hızı
    public Slider sensitivitySlider;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        // Fareyi kilitle
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void setSensitivty()
    {
        mouseSensitivity = sensitivitySlider.value;
    }

    private void Update()
    {
        // Fare hareketini al
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Yatay dönüşü uygula (karakterin yönüne göre)
        playerBody.Rotate(Vector3.up * mouseX);

        // Dikey dönüşü uygula (sınırlı açı ile)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Aşırı yukarı/aşağı dönüşü engelle
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Yatay dönüşü uygula (kameranın kendi yönüne göre)
        yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Kamerayı karakterin pozisyonuna sabitle
        transform.position = playerBody.position;

        // Yatay hareketi (sağa sola) uygula
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * horizontalMovement);
    }
}