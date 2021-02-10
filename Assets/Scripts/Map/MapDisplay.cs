using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MapDisplay : MonoBehaviourSingleton<MapDisplay>
{
    [SerializeField] private MapFactory mapFactory;
    [SerializeField] private GameObject mapLayer;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI mapNameText;
    [SerializeField] private TextMeshProUGUI difficultyText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image featuredImage;
    public void DisplayMap(string sceneName)
    {
        Map map = mapFactory.GetMap(sceneName);
        if (map != null) DisplayMap(map);
    }
    public void DisplayMap(Map map)
    {
        mapLayer.SetActive(true);
        levelText.text = string.Format("Level {0}", map.Level);
        mapNameText.text = map.MapName;
        difficultyText.text = map.Difficulty;
        descriptionText.text = map.Description;
        featuredImage.sprite = map.FeaturedImage;
    }
    public void HideMap()
    {
        mapLayer.SetActive(false);
    }
}
