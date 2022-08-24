using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager
{
    
    //Main Menu
    public static bool IsInitializedMainMenu { get; private set; }
    public static GameObject mainMenu, settingsMenu;

    //In Game
    public static bool IsInitializedInGame { get; private set; }
    public static GameObject pauseMenu;

    public static void InitMainMenu()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;

        IsInitializedMainMenu = true;
    }

    public static void InitInGame()
    {
        GameObject canvas = GameObject.Find("Canvas");
        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;

        IsInitializedInGame = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitializedMainMenu && SceneManager.GetActiveScene().name.Equals("MainMenuScene")) InitMainMenu();
        else if (!IsInitializedInGame && SceneManager.GetActiveScene().name.Equals("SampleScene")) InitInGame();

        switch (menu)
        {
            case Menu.MainMenu:
                mainMenu.SetActive(true);
                break;
            case Menu.Settings:
                mainMenu.SetActive(true);
                break;
            case Menu.PauseMenu:
                pauseMenu.SetActive(true);
                break;

        }
        if(callingMenu != null) callingMenu.SetActive(false);
    }


}
