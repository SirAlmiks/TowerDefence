using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverUI;

    void Start() {
        gameOver = false;
    }
    void Update()
    {
        if(gameOver)
            return;
        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        gameOver = true;
        GameOverUI.SetActive(true);
    }
}
