using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vector2Extensions;
using System;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool bombPool;
    [SerializeField] private ObjectPool explosionPool;
    [SerializeField] private float damage = 20f;
    [SerializeField] private int length = 2;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int bombLimit = 999;
    [SerializeField] private UnityEvent onBombPlaced;
    public Action OnDamageChanged { get; set; }
    public Action OnLengthChanged { get; set; }
    public Action OnBombLimitChanged { get; set; }
    private List<Vector2> bombPositions = new List<Vector2>();
    private CharacterType characterType;
    public float Damage
    {
        get => damage; set
        {
            damage = value;
            OnDamageChanged?.Invoke();
        }
    }
    public int Length
    {
        get => length; set
        {
            length = value;
            OnLengthChanged?.Invoke();
        }
    }
    public int BombLimit
    {
        get => bombLimit; set
        {
            bombLimit = value;
            OnBombLimitChanged?.Invoke();
        }
    }
    private void Awake()
    {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    public void PlaceBomb(Vector2 position)
    {
        if (bombPositions.Count >= bombLimit) return;
        Vector2 cellCenterPos = position.ToCellCenter();
        if (bombPositions.Contains(cellCenterPos)) return;
        bombPositions.Add(cellCenterPos);
        CreateBomb(cellCenterPos);
        onBombPlaced?.Invoke();
    }
    public void ThrowBomb(Vector2 destination, float throwSpeed)
    {
        Bomb b = CreateBomb();
        Vector2 cellCenterPos = destination.ToCellCenter();
        b.Destination = cellCenterPos;
        b.Speed = throwSpeed;
    }
    private Bomb CreateBomb(Vector2 position)
    {
        Bomb b = bombPool.Get(position).GetComponent<Bomb>();
        b.BombSpawner = this;
        b.Damage = damage;
        b.Lifetime = lifetime;
        b.Length = length;
        b.CharacterType = characterType;
        b.ExplosionPool = explosionPool;
        return b;
    }
    private Bomb CreateBomb()
    {
        return CreateBomb(transform.position);
    }
    public void PlaceBomb()
    {
        PlaceBomb(transform.position);
    }
    public void RemoveBombPosition(Vector3 pos)
    {
        bombPositions.Remove(pos);
    }
}
