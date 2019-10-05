using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene(){
        // This reloads the current scene. The SceneManager.LoadScene() function is
        // how you load different levels in Unity :)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
