using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{ 
    private Scene currentScene;
    private GameObject GM;
    private GameObject AM;

    void Start() 
    { 
        currentScene = SceneManager.GetActiveScene();
        AM = GameObject.FindGameObjectWithTag("AUDIO");
        AM.GetComponent<AudioManager>().Play("Daybreak");
    }

    public void PlayGame()
    {
        if (currentScene.name == "StartScreen") 
        {
            AM = GameObject.FindGameObjectWithTag("AUDIO");
            AM.GetComponent<AudioManager>().Play("InspiringPiano");
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else if (currentScene.name == "ChoiceScreen")
        {
            GM = GameObject.FindGameObjectWithTag("GM");
            Destroy(GM);
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
