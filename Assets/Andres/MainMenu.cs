using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public string playScene = "SampleScene";
    public string mainMenu = "";

    public GameObject creditsPanel;
    public GameObject menuPanel;
    public GameObject pauseMenuPanel;

    public MonoBehaviour[] inputScripts;

    public bool mainMenuActive = true;
    public bool pauseMenuActive = false;

    public void PressForUI(InputAction.CallbackContext context)
    {
        if(context.performed && !mainMenuActive)
        {
            Debug.Log("pause please");
            if (pauseMenuActive)
            {
                Resume();
            }
            else
            {
                Pause();             
            }
        }

        if (context.performed)
        {
            Debug.Log("pressed");
        }
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P) )
        {
            
        }*/
    }

    public void StartGame()
    {
        TurnOffAllPanels();
        mainMenuActive = false;

        //Camera pans out

        //SceneManager.LoadScene(playScene);
    }

    public void BacktoMainMenu()
    {
        mainMenuActive = true;
        //Reset the game

        //SceneManager.LoadScene(mainMenu);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuActive = true;
        pauseMenuPanel.SetActive(true);

        for (int i = 0; i < inputScripts.Length; i++)
        {
            inputScripts[i].enabled = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuActive = false;
        pauseMenuPanel.SetActive(false);

        for (int i = 0; i < inputScripts.Length; i++)
        {
            inputScripts[i].enabled = true;
        }
    }

    public void BackButton()
    {
        creditsPanel.SetActive(false);

        if(mainMenuActive == true)
        {
            menuPanel.SetActive(true);
        }
        else if (mainMenuActive == false)
        {
            pauseMenuPanel.SetActive(true);
        }
        
    }

    public void CreditsButton(string fromWhere)
    {
        creditsPanel.SetActive(true);

        if (fromWhere == "Main")
        {
            menuPanel.SetActive(false);
        }
        else if (fromWhere == "Pause")
        {
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            print("Where you going to credits from?");
        }
    }

    public void TurnOffAllPanels()
    {
        creditsPanel.SetActive(false);
        menuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
    }


}
