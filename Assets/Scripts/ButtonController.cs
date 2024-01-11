using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit () {
        Application.Quit();
    }

    public void Restart() {
        SceneManager.LoadScene("MainMenuScene");
    }
    
}
