using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    [SerializeField] private string id = "";
    private string xKey;
    private string yKey;
    private void Start()
    {
        xKey = id+"X";
        yKey =id+"Y";
        float x = PlayerPrefs.GetFloat(xKey, transform.position.x);
        float y = PlayerPrefs.GetFloat(yKey, transform.position.y);
        transform.position = new Vector3(x, y, 0);
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(xKey, transform.position.x);
        PlayerPrefs.SetFloat(yKey, transform.position.y);
    }
}
