using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    private GameManager gameManager;
    private Image scoreBar;
    private void Awake()
    {
        scoreBar = GetComponent<Image>();
    }
    private void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager == null) return;
        gameManager.OnScoreUpdated += UpdateScoreBar;
        UpdateScoreBar();
    }
    private void UpdateScoreBar()
    {
        if (gameManager == null) return;
        scoreBar.fillAmount = gameManager.Progress;
    }
    private void OnDestroy()
    {
        gameManager.OnScoreUpdated -= UpdateScoreBar;
    }
}
