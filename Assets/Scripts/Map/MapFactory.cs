using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MapFactory", fileName = "MapFactory")]
public class MapFactory : ScriptableObject
{
    [SerializeField] private Map[] maps;
    private Dictionary<int, Map> mapDictionary = new Dictionary<int, Map>();
    private void OnEnable()
    {
        foreach (var map in maps)
        {
            mapDictionary[map.Level] = map;
        }
    }
    public Map GetMap(int level)
    {
        if (mapDictionary.ContainsKey(level)) return mapDictionary[level];
        return null;
    }
}
