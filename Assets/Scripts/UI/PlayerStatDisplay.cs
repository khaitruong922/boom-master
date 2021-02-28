using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerStatDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bombLimitText, damageText, lengthText, moveSpeedText;
    private BombSpawner bombSpawner;
    private MoveComponent moveComponent;
    private void Start()
    {
        Player player = Player.Instance;
        bombSpawner = player.GetComponentInChildren<BombSpawner>();
        moveComponent = player.GetComponent<MoveComponent>();
        bombSpawner.OnBombLimitChanged += UpdateBombLimitText;
        bombSpawner.OnDamageChanged += UpdateDamageText;
        bombSpawner.OnLengthChanged += UpdateLengthText;
        moveComponent.OnMoveSpeedChanged += UpdateMoveSpeedText;
        UpdateAll();
    }

    private void UpdateMoveSpeedText()
    {
        moveSpeedText.text = (moveComponent.MoveSpeed * 100).ToString();
    }

    private void UpdateLengthText()
    {
        lengthText.text = bombSpawner.Length.ToString();
    }

    private void UpdateDamageText()
    {
        damageText.text = bombSpawner.Damage.ToString();
    }

    private void UpdateBombLimitText()
    {
        bombLimitText.text = bombSpawner.BombLimit.ToString();
    }
    private void UpdateAll()
    {
        UpdateMoveSpeedText();
        UpdateLengthText();
        UpdateDamageText();
        UpdateBombLimitText();
    }
    private void OnDestroy()
    {
        bombSpawner.OnBombLimitChanged -= UpdateBombLimitText;
        bombSpawner.OnDamageChanged -= UpdateDamageText;
        bombSpawner.OnLengthChanged -= UpdateLengthText;
        moveComponent.OnMoveSpeedChanged -= UpdateMoveSpeedText;
    }
}
