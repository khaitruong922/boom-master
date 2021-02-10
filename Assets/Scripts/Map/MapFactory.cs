using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MapFactory", fileName = "MapFactory")]
public class MapFactory : ScriptableObject
{
    [SerializeField] private Map[] maps;
    private Dictionary<string, Map> mapDictionary = new Dictionary<string, Map>();
    private void OnEnable()
    {
        foreach (var map in maps)
        {
            mapDictionary[map.SceneName] = map;
        }
    }
    public Map GetMap(string sceneName)
    {
        if (sceneName == null) return null;
        if (mapDictionary.ContainsKey(sceneName)) return mapDictionary[sceneName];
        return null;
    }
}
