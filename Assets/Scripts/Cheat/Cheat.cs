using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    private const float veryLargeNumber = 100000;
    public static void KillAllEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Health>().TakeDamage(veryLargeNumber);
        }
    }
    public static void Heal()
    {
        Player.Instance.GetComponent<Health>().Heal(veryLargeNumber);
    }
}
