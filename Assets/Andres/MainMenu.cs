using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string play_scene = "ControllerTesting";
    public string main_menu = "";

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
        SceneManager.LoadScene(play_scene);
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(main_menu);
    }
}
