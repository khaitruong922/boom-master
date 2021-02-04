using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextSpawner : MonoBehaviour
{
    [SerializeField] private PoolObjectFactory poolObjectFactory;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private Color healColor = Color.green;
    private void Start()
    {
        Health.OnCharacterHealthChanged += Spawn;
    }
    private void Spawn(float changedAmount, Health health)
    {
        TextMeshPro floatingText = poolObjectFactory.Get(health.transform.position, Quaternion.identity, health.transform).GetComponent<TextMeshPro>();
        int displayAmount = (int)Mathf.Abs(changedAmount);
        floatingText.text = displayAmount.ToString();
        floatingText.color = changedAmount > 0 ? healColor : damageColor;
    }
    private void OnDestroy()
    {
        Health.OnCharacterHealthChanged -= Spawn;
    }

}
