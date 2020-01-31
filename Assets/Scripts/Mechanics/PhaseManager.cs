using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager instance;
    int role = 1;

    public Text phaseText;
    private PlayerStats playerStats;

    void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerStats>();
        role = 1;
        ChangePhase();
        if (instance != null) {
            Debug.LogError("Ошибка: Более одного PhaseManager на сцене");
            return;
        }    
        instance = this;
    }

    public void ChangePhase() {
        if (role == 1){
            phaseText.text = "Игрок 2 - Атакует\nИгрок 1 - Защищается";
            playerStats.role = 2;
            role = 2;
        }
        else {
            phaseText.text = "Игрок 1 - Атакует\nИгрок 2 - Защищается";
            playerStats.role = 1;
            role = 1;
        }
    }
}
