using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectZone : MonoBehaviour
{
    [SerializeField] private string mapSceneName;
    private bool isTriggeredByPlayer = false;
    private MapDisplay mapDisplay;
    private void Start()
    {
        mapDisplay = MapDisplay.Instance;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) return;
        isTriggeredByPlayer = true;
        mapDisplay.VisitedMapSceneName = mapSceneName;
        mapDisplay.SetTooltipText(string.Format("Press {0} to continue", mapDisplay.DisplayKey.ToString()));
        mapDisplay.SetLocationText(mapSceneName);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) return;
        isTriggeredByPlayer = false;
        mapDisplay.VisitedMapSceneName = null;
        mapDisplay.SetLocationTextToDefault();
        mapDisplay.SetTooltipTextToDefault();
    }
}
