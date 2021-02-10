using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    [SerializeField] private string id = "";
    private void Start()
    {
        float x = PlayerPrefs.GetFloat( id+"X", transform.position.x);
        float y = PlayerPrefs.GetFloat(id+"Y", transform.position.y);
        transform.position = new Vector3(x, y, 0);
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(id+"X", transform.position.x);
        PlayerPrefs.SetFloat(id+"Y", transform.position.y);
    }
}
