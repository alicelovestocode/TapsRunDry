using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{ 
    private Scene currentScene;
    private GameObject GM;

    void Start() { currentScene = SceneManager.GetActiveScene(); }

    public void ChangeScene() { SceneManager.LoadScene(currentScene.buildIndex + 1); }

    public void PlayGame() 
    {
        if (currentScene.name == "StartScreen") { SceneManager.LoadScene(currentScene.buildIndex + 1); }
        else if (currentScene.name == "ChoiceScreen")
        {
            GM = GameObject.FindGameObjectWithTag("GM");
            Destroy(GM);
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void QuitGame()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}