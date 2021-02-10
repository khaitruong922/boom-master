using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private int requiredScore = 200;
    [SerializeField] private float endGameDelay = 2;
    public Action OnVictory { get; set; }
    public Action OnDefeat { get; set; }
    public Action OnScoreUpdated { get; set; }
    private int currentScore = 0;
    private bool isPlaying = true;

    private void Start()
    {
        Enemy.OnAnyEnemyKilled += IncreaseScore;
        Player.Instance.OnPlayerDead += Defeat;
    }
    private void IncreaseScore(int score)
    {
        if (!isPlaying) return;
        currentScore += score;
        OnScoreUpdated?.Invoke();
        if (currentScore >= requiredScore) Victory();
    }
    private void Victory()
    {
        if (!isPlaying) return;
        print("Victory");
        isPlaying = false;
        StartCoroutine(VictoryCoroutine());
    }
    private IEnumerator VictoryCoroutine()
    {
        yield return new WaitForSeconds(endGameDelay);
        OnVictory?.Invoke();
        Time.timeScale = 0;
    }
    private void Defeat()
    {
        if (!isPlaying) return;
        print("Defeat");
        isPlaying = false;
        StartCoroutine(DefeatCoroutine());
    }
    private IEnumerator DefeatCoroutine()
    {
        yield return new WaitForSeconds(endGameDelay);
        OnDefeat?.Invoke();
        Time.timeScale = 0;
    }
    public int RequiredScore => requiredScore;
    public int CurrentScore => currentScore;
    public float Progress => (float)currentScore / (float)requiredScore;
    private void OnDestroy()
    {
        Enemy.OnAnyEnemyKilled -= IncreaseScore;

    }
}
