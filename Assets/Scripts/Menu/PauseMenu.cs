using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static Action OnResume;
    public void OnClickResume()
    {
        OnResume?.Invoke();
        gameObject.SetActive(false);
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
