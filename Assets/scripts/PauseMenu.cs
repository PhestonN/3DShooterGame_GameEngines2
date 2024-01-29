using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI; // Ana Men� paneli
    public GameObject optionsMenuUI; // Options Men� paneli
    private bool isPaused = false; // Oyunun duraklat�ld��� durumu tutar
    private AudioSource[] allAudioSources;

    void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        // Escape tu�una bas�ld���nda
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        // Fare giri�ini kontrol et
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None; // Fareyi serbest b�rak
            Cursor.visible = true; // Fareyi g�ster
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // Fareyi kilitle
            Cursor.visible = false; // Fareyi gizle
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Ana Men� panelini gizle
        optionsMenuUI.SetActive(false); // Options Men� panelini gizle
        Time.timeScale = 1f; // Oyun zaman�n� normale �evir (devam ettir)
        isPaused = false; // Oyun durumunu g�ncelle

        // Sesleri tekrar ba�lat
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Ana Men� panelini g�ster
        optionsMenuUI.SetActive(false); // Options Men� panelini gizle
        Time.timeScale = 0f; // Oyun zaman�n� durdur
        isPaused = true; // Oyun durumunu g�ncelle

        // Sesleri duraklat
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    public void ShowOptions()
    {
        optionsMenuUI.SetActive(true); // Options Men� panelini g�ster
        pauseMenuUI.SetActive(false); // Ana Men� panelini gizle
    }

    public void Menu()
    {
        optionsMenuUI.SetActive(false); // Options Men� panelini g�ster
        pauseMenuUI.SetActive(true); // Ana Men� panelini gizle
    }

    public void MainMenu()
    {

        SceneManager.LoadScene(0);

    }
}
