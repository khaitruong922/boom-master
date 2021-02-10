using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectZone : MonoBehaviour
{
    [SerializeField] private KeyCode selectKey = KeyCode.K;
    [SerializeField] private string mapSceneName;
    private MapDisplay mapDisplay;
    private static string visitedMapSceneName;
    private void Start()
    {
        mapDisplay = MapDisplay.Instance;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) return;
        visitedMapSceneName = mapSceneName;
        mapDisplay.SetTooltipText(string.Format("Press {0} to continue", selectKey.ToString()));
        mapDisplay.SetLocationText(visitedMapSceneName);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) return;
        visitedMapSceneName = null;
        mapDisplay.SetLocationTextToDefault();
        mapDisplay.SetTooltipTextToDefault();
    }
    private void Update()
    {
        if (Input.GetKeyDown(selectKey))
        {
            if (mapDisplay.IsDisplaying)
            {
                mapDisplay.HideMap();
            }
            else
            {
                mapDisplay.DisplayMap(visitedMapSceneName);
            }
        }
    }
}
