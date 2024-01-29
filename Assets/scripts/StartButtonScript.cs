using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButtonScript : MonoBehaviour
{
   
        void Start()
        {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        }
    



    // Start d��mesine t�klan�nca �a�r�lacak fonksiyon
    public void OnStartButtonClicked()
    {
        // Mevcut sahnenin index'ini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Bir sonraki sahnenin index'ini belirle
        int nextSceneIndex = currentSceneIndex + 1;

        // E�er bir sonraki sahne index'i mevcut toplam sahne say�s�n� a��yorsa, ba�a d�n.
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        // Yeni sahneye ge�i� yap
        SceneManager.LoadScene(nextSceneIndex);

    }
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void MainMenu()
    {

        SceneManager.LoadScene(0);

    }

}
