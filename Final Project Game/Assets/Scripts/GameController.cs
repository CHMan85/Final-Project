using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    public void GameOver(int score)
    {
        Debug.Log("Calling the gameOverScreen Setup");
        gameOverScreen.Setup(score);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Pause();
    }

    public void unpauseGame()
    {
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
    }
}
