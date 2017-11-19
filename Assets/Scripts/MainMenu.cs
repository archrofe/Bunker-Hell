using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [Header("Bools")]
    
    public bool loadBool;
    
    public bool fullscreenBool;
    public bool makeFullscreen;
    public bool inGame;
    public bool pauseBool;
    public bool showPause;
    public bool musicPlay;

    [Header("GameObjects")]
    public GameObject mainMenu;   
    public GameObject loadMenu;    

   

   

    

   

    public void Awake()
    {
        Time.timeScale = 1;
       

    }

    

    public void Start()
    {
        inGame = false;
       
       
        
       
    }

    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            mainMenu.SetActive(true);
            TogglePause();
        }


       
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        inGame = true;
    }

    

   
    

    

    

    

    

    public void ShowLoadMenu()
    {
        ToggleLoadMenu();
    }

    public bool ToggleLoadMenu()
    {
        if (loadBool)
        {
            mainMenu.SetActive(true);
            loadMenu.SetActive(false);
            loadBool = false;
            return false;
        }
        else
        {
            mainMenu.SetActive(false);
            loadMenu.SetActive(true);
            loadBool = true;
            return true;
        }
    }

    

    

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

   

    public void Resume()
    {
        TogglePause();
    }

    public bool TogglePause()
    {
        if (pauseBool)
        {
            if (!showPause)
            {
                Time.timeScale = 1;
                pauseBool = false;
                mainMenu.SetActive(false);
            }
            else
            {
                showPause = false;
                mainMenu.SetActive(true);
            }
            return false;
        }
        else
        {
            Time.timeScale = 0;
            pauseBool = true;
            mainMenu.SetActive(true);
            return true;
        }
    }
}
