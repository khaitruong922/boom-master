using UnityEngine;

[System.Serializable]
public class PoolObjectFactory
{
    [SerializeField] private PoolObjectType type;
    [SerializeField] private Color color = Color.white;
    public GameObject Get(Vector3 position, Quaternion quaternion)
    {
        GameObject g = PoolManager.Instance.Get(type, position, quaternion);
        var sr = g.GetComponentInChildren<SpriteRenderer>();
        if (sr != null) sr.color = color;
        return g;
    }
    public GameObject Get(Vector3 position)
    {
        return Get(position, Quaternion.identity);
    }
    public void Spawn(Vector3 position)
    {
        Get(position, Quaternion.identity);
    }
}
