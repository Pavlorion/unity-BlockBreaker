using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameSession gameStatus;

    public void LoadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        
        SceneManager.LoadScene(0);
        gameStatus = FindObjectOfType<GameSession>();
        gameStatus.RestartScore();

    }
        
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
