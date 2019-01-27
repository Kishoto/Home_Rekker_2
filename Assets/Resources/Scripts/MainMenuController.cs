using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        creditsButton.onClick.AddListener(LoadCredits);
    }

    void StartGame()
    {
        SceneManager.LoadScene("levelSelect");
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
