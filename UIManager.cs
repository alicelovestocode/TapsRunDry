using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    private Scene currentScene;

    void Start() { currentScene = SceneManager.GetActiveScene(); }

    public void ChangeScene()
    {
        Debug.Log("current scene before: " + (currentScene.buildIndex));
        SceneManager.LoadScene(currentScene.buildIndex + 1);
        Debug.Log("current scene after: " + (currentScene.buildIndex));
    }

    public void PlayGame() {

        if (currentScene.name == "StartScreen") 
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else if (currentScene.name == "LevelOne") {
            SceneManager.LoadScene(currentScene.name);
        }

    }

    public void QuitGame() {

        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

    }

}