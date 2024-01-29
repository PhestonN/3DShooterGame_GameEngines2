using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
       
        LoadNextScene();
        
        
    }

    void LoadNextScene()
    {
        // Mevcut sahnenin build index'ini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Bir sonraki sahnenin build index'ini hesapla
        int nextSceneIndex = currentSceneIndex + 1;

        // Bir sonraki sahneye geçiþ yap
        SceneManager.LoadScene(nextSceneIndex);
    }
}
