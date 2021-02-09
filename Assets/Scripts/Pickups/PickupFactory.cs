using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PickupFactory", fileName = "PickupFactory")]
public class PickupFactory : ScriptableObject
{
    [System.Serializable]
    private class PickupDrop
    {
        [SerializeField]
        private GameObject pickup;
        public GameObject Pickup => pickup;
        [SerializeField]
        private int dropWeight = 10;
        public int DropWeight => dropWeight;
    }
    [SerializeField] private int totalDropWeight = 100;
    [SerializeField] private PickupDrop[] pickupDrops;
    private int[] dropTable;
    private void OnEnable()
    {
        dropTable = new int[pickupDrops.Length];
        int cumulativeWeight = 0;
        for (int i = 0; i < pickupDrops.Length; i++)
        {
            cumulativeWeight += pickupDrops[i].DropWeight;
            dropTable[i] = cumulativeWeight;
        }
        if (cumulativeWeight > totalDropWeight) Debug.LogWarning($"Cumulative weight is higher than drop weight.");
    }
    public GameObject GetRandomPickup()
    {
        if (dropTable.Length == 0) return null;
        int randomNumber = Random.Range(1, totalDropWeight);
        for (int i = 0; i < dropTable.Length; i++)
        {
            if (randomNumber <= dropTable[i]) return pickupDrops[i].Pickup;
        }
        return null;
    }
}
