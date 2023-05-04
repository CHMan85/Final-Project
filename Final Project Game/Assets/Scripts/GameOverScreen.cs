using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public GameController gameController;

    public void Start()
    {
        gameObject.SetActive(false);
    }



    public void Setup(int score)
    {
        //Debug.Log("Setup Called");
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        gameController.pauseGame();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Running");
        gameController.unpauseGame();        
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
        gameController.unpauseGame();
    }

    public void QuitButton()
    {
        gameController.QuitGame();
    }
    


}
