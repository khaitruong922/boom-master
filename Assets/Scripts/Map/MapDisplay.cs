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
    private bool isDisplaying = false;
    public bool IsDisplaying => isDisplaying;
    public void DisplayMap(string sceneName)
    {
        Map map = mapFactory.GetMap(sceneName);
        if (map != null) DisplayMap(map);
    }
    public void DisplayMap(Map map)
    {
        Time.timeScale = 0;
        isDisplaying = true;
        PlayerPrefs.SetString(SceneLoader.levelKey, map.SceneName);
        mapLayer.SetActive(true);
        levelText.text = string.Format("Level {0}", map.Level);
        mapNameText.text = map.MapName;
        difficultyText.text = map.Difficulty;
        descriptionText.text = map.Description;
        featuredImage.sprite = map.FeaturedImage;
    }
    public void HideMap()
    {
        PlayerPrefs.SetString(SceneLoader.levelKey, "");
        Time.timeScale = 1;
        isDisplaying = false;
        mapLayer.SetActive(false);
    }
}
