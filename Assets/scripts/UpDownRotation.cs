using UnityEngine;

public class UpDownRotation : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Hareket h�z�
    public float rotationSpeed = 50.0f; // D�n�� h�z�
    public float maxHeight = 5.0f; // Maksimum y�kseklik
    public float minHeight = 1.0f; // Minimum y�kseklik

    private int direction = 1; // Hareket y�n�: 1 yukar�, -1 a�a��

    void Update()
    {
        // Hareketi ve d�n��� g�ncelle
        MoveUpDown();
        Rotate();
    }

    void MoveUpDown()
    {
        // Y�ksekli�i g�ncelle
        float newHeight = transform.position.y + moveSpeed * direction * Time.deltaTime;

        // Y�kseklik s�n�rlar�n� kontrol et
        if (newHeight > maxHeight)
        {
            newHeight = maxHeight;
            direction = -1; // Y�kseklik s�n�r�na ula��ld���nda a�a�� y�nde hareket et
        }
        else if (newHeight < minHeight)
        {
            newHeight = minHeight;
            direction = 1; // Minimum y�ksekli�e ula��ld���nda yukar� y�nde hareket et
        }

        // Yeni y�kseklik de�erini uygula
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }

    void Rotate()
    {
        // D�n��� g�ncelle
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
