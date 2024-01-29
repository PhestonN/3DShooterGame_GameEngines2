using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı
    public float sprintSpeed = 10f; // Hızlandırılmış hareket hızı
    public float jumpForce = 10f; // Zıplama kuvveti
    private Rigidbody rb;
    private bool isGrounded = true; // Yerde mi kontrolü
    private bool isWalking = false; // Yürüyor mu kontrolü
    private float currentSpeed; // Şu anki hız

    public AudioSource footstepAudioSource; // Yürüme sesi için AudioSource
    public AudioClip walkingSound; // Ayak sesi

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // AudioSource bileşenini kontrol et
        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Klavyeden girişi al
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Hareket vektörü oluştur
        Vector3 movement = transform.right * moveX + transform.forward * moveZ;

        // Hızlı koşma kontrolü
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            movement *= sprintSpeed; // Hızı iki katına çıkar
            currentSpeed = sprintSpeed;
        }
        else
        {
            movement *= moveSpeed;
            currentSpeed = moveSpeed;
        }

        // Karakteri hareket ettir
        rb.MovePosition(rb.position + movement * Time.deltaTime);

        // Yerdeyken zıplama
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Zıpladığında yerde olmadığını belirt
        }

        // Karakter yürüdüğünde/ayakta olduğunda ayak sesini çal
        if (movement != Vector3.zero && isGrounded)
        {
            if (!isWalking)
            {
                footstepAudioSource.clip = walkingSound; // Yürüme sesini ata
                footstepAudioSource.Play();
                isWalking = true;
            }
        }
        else
        {
            // Karakter durduğunda veya zıpladığında ayak sesini durdur
            footstepAudioSource.Stop();
            isWalking = false;
        }

        // Hızlandığında pitch'i artır
        if (currentSpeed == sprintSpeed && footstepAudioSource.isPlaying)
        {
            footstepAudioSource.pitch = 1.5f; // Örnek olarak 1.5 kat hızlandırma
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        // Karakter bir yerde duruyorsa, isGrounded'i true yap
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
