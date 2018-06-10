using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static gameManager Instance;

    public GameObject menu;
    public Text scoreText;

    enum PageState
    {
        None,
        Start,
        GameOver
    }

    int score = 0;
    bool gameOver = false;

    public bool GameOver { get { return gameOver; } }

    void Awake()
    {
        Instance = this;
    }

    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                menu.SetActive(false);
                break;

            case PageState.Start:
                menu.SetActive(true);
                break;

            case PageState.GameOver:
                menu.SetActive(true);
                break;
        }
    }

    public void StartGame()
    {

    } 
}
