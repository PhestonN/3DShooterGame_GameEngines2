using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI; // Ana Menü paneli
    public GameObject optionsMenuUI; // Options Menü paneli
    private bool isPaused = false; // Oyunun duraklatýldýðý durumu tutar
    private AudioSource[] allAudioSources;

    void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        // Escape tuþuna basýldýðýnda
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

        // Fare giriþini kontrol et
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None; // Fareyi serbest býrak
            Cursor.visible = true; // Fareyi göster
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
        pauseMenuUI.SetActive(false); // Ana Menü panelini gizle
        optionsMenuUI.SetActive(false); // Options Menü panelini gizle
        Time.timeScale = 1f; // Oyun zamanýný normale çevir (devam ettir)
        isPaused = false; // Oyun durumunu güncelle

        // Sesleri tekrar baþlat
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Ana Menü panelini göster
        optionsMenuUI.SetActive(false); // Options Menü panelini gizle
        Time.timeScale = 0f; // Oyun zamanýný durdur
        isPaused = true; // Oyun durumunu güncelle

        // Sesleri duraklat
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    public void ShowOptions()
    {
        optionsMenuUI.SetActive(true); // Options Menü panelini göster
        pauseMenuUI.SetActive(false); // Ana Menü panelini gizle
    }

    public void Menu()
    {
        optionsMenuUI.SetActive(false); // Options Menü panelini göster
        pauseMenuUI.SetActive(true); // Ana Menü panelini gizle
    }

    public void MainMenu()
    {

        SceneManager.LoadScene(0);

    }
}
