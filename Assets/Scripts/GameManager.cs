using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);

        Player.OnPlayerTouchedObstacle += GameOver;
        GameOverScreen.OnRestart += RestartGame;

        InputManager.Instance.OnPauseStarted += PauseGame;
        PauseMenu.OnResume += ResumeGame;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        MenuManager.OpenMenu(Menu.PauseMenu, null);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Player.OnPlayerTouchedObstacle -= GameOver;
        GameOverScreen.OnRestart -= RestartGame;
        Player.GameOver = false;

        InputManager.Instance.OnPauseStarted -= PauseGame;
        PauseMenu.OnResume -= ResumeGame;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
