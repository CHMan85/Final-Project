using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameController gameController;

    public void Start()
    {
        gameObject.SetActive(false);
    }


    public void PauseButton()
    {
        gameObject.SetActive(true);
        gameController.pauseGame();
    }

    public void ResumeButton()
    {
        gameController.unpauseGame();
        gameObject.SetActive(false);
    }

    public void QuitButton()
    {
        gameController.QuitGame();
    }
}
