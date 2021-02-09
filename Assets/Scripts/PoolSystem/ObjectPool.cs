using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    [SerializeField] private PoolObjectType type;
    [SerializeField] private Color color = Color.white;
    public Color Color { get => color; set => color = value; }

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
