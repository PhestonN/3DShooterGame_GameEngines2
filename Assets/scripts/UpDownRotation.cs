using UnityEngine;

public class UpDownRotation : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Hareket hýzý
    public float rotationSpeed = 50.0f; // Dönüþ hýzý
    public float maxHeight = 5.0f; // Maksimum yükseklik
    public float minHeight = 1.0f; // Minimum yükseklik

    private int direction = 1; // Hareket yönü: 1 yukarý, -1 aþaðý

    void Update()
    {
        // Hareketi ve dönüþü güncelle
        MoveUpDown();
        Rotate();
    }

    void MoveUpDown()
    {
        // Yüksekliði güncelle
        float newHeight = transform.position.y + moveSpeed * direction * Time.deltaTime;

        // Yükseklik sýnýrlarýný kontrol et
        if (newHeight > maxHeight)
        {
            newHeight = maxHeight;
            direction = -1; // Yükseklik sýnýrýna ulaþýldýðýnda aþaðý yönde hareket et
        }
        else if (newHeight < minHeight)
        {
            newHeight = minHeight;
            direction = 1; // Minimum yüksekliðe ulaþýldýðýnda yukarý yönde hareket et
        }

        // Yeni yükseklik deðerini uygula
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }

    void Rotate()
    {
        // Dönüþü güncelle
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
