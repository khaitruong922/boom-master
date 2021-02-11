using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Map
{
    [SerializeField] private string sceneName;
    [SerializeField] private int level;
    [SerializeField] private string mapName;
    [SerializeField] private string difficulty;
    [SerializeField] private Color difficultyColor = Color.white;
    [TextArea(3, 5)] [SerializeField] private string description;
    [SerializeField] private Sprite featuredImage;
    public string SceneName => sceneName;
    public int Level => level;
    public string MapName => mapName;
    public string Difficulty => difficulty;
    public Color DifficultyColor => difficultyColor;
    public string Description => description;
    public Sprite FeaturedImage => featuredImage;
}