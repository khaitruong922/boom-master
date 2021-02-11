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
    [SerializeField] private TextMeshProUGUI locationText;
    [SerializeField] private TextMeshProUGUI tooltipText;
    [SerializeField] private KeyCode displayKey = KeyCode.E;
    [SerializeField] private string defaultTooltip = "Let\'s find a battle";
    public KeyCode DisplayKey => displayKey;
    public string VisitedMapSceneName { get; set; }
    private bool isDisplaying = false;
    private string defaultLocation = "Lobby";
    private void Start()
    {
        HideMap();
        SetLocationTextToDefault();
        SetTooltipTextToDefault();
    }
    private void Update()
    {
        if (Input.GetKeyDown(displayKey)) DisplayVisitedMap();
    }
    public void DisplayVisitedMap()
    {
        if (isDisplaying)
        {
            HideMap();
        }
        else
        {
            DisplayMap(VisitedMapSceneName);
        }
    }
    public void DisplayMap(string sceneName)
    {
        Map map = mapFactory.GetMap(sceneName);
        if (map == null) return;
        Time.timeScale = 0;
        isDisplaying = true;
        mapLayer.SetActive(true);
        PlayerPrefs.SetString(SceneLoader.levelKey, map.SceneName);
        levelText.text = string.Format("Level {0}", map.Level);
        mapNameText.text = map.MapName;
        difficultyText.text = map.Difficulty;
        difficultyText.color = map.DifficultyColor;
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
    public void SetLocationText(string sceneName)
    {
        Map map = mapFactory.GetMap(sceneName);
        locationText.text = string.Format("Level {0} - {1}", map.Level, map.MapName);
    }
    public void SetLocationTextToDefault()
    {
        locationText.text = defaultLocation;
    }
    public void SetTooltipText(string text)
    {
        tooltipText.text = text;
    }
    public void SetTooltipTextToDefault()
    {
        tooltipText.text = defaultTooltip;
    }
}
