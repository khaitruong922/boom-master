using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool floatingTextPool;
    [Header("Health")]
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private Color healColor = Color.green;
    [Header("Score")]
    [SerializeField] private Color scoreColor = Color.yellow;
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = Player.Instance.transform;
        Health.OnAnyCharacterHealthChanged += SpawnDamageText;
        Enemy.OnAnyEnemyKilled += SpawnScoreText;
    }
    private void SpawnScoreText(int score)
    {
        TextMeshPro floatingText = floatingTextPool.Get(playerTransform.position).GetComponent<TextMeshPro>();
        floatingText.GetComponent<TransformAttach>().AttachTransform = playerTransform;
        floatingText.text = string.Format("+{0}", score);
        floatingText.color = scoreColor;
    }
    private void SpawnDamageText(float changedAmount, Health health)
    {
        TextMeshPro floatingText = floatingTextPool.Get(health.transform.position).GetComponent<TextMeshPro>();
        floatingText.GetComponent<TransformAttach>().AttachTransform = health.transform;
        int displayAmount = (int)Mathf.Abs(changedAmount);
        floatingText.text = displayAmount.ToString();
        floatingText.color = changedAmount > 0 ? healColor : damageColor;
    }
    private void OnDestroy()
    {
        Health.OnAnyCharacterHealthChanged -= SpawnDamageText;
        Enemy.OnAnyEnemyKilled -= SpawnScoreText;
    }

}
