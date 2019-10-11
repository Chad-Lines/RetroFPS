using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to switch scenes
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;           // Level to open on "Start" button
    public GameObject optionsScreen;    // The "Options" screen

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
