using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDisplay : MonoBehaviour
{
    [SerializeField] private GameObject victoryDisplay;
    [SerializeField] private GameObject defeatDisplay;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnVictory += DisplayVictory;
        gameManager.OnDefeat += DisplayDefeat;
    }
    private void DisplayDefeat()
    {
        defeatDisplay.SetActive(true);
    }
    private void DisplayVictory()
    {
        victoryDisplay.SetActive(true);
    }
    private void OnDestroy()
    {
        gameManager.OnVictory -= DisplayVictory;
        gameManager.OnDefeat -= DisplayDefeat;
    }
}
