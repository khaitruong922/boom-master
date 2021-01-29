using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab;
    [SerializeField]
    private int initialCount = 50;
    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        AddObjects(initialCount);
    }
    public T Get()
    {
        if (objects.Count == 0)
            AddObjects(1);
        return objects.Dequeue();
    }
    protected void AddObjects(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            T t = Instantiate(prefab).GetComponent<T>();
            t.gameObject.SetActive(false);
            objects.Enqueue(t);
        }
    }
    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}