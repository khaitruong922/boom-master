using System.Collections.Generic;
using UnityEngine;
using Vector2Extensions;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private PoolObjectFactory bombFactory;
    [SerializeField] private float damage = 20f;
    [SerializeField] private int length = 2;
    [SerializeField] private float lifetime = 2f;
    private List<Vector2> bombPositions = new List<Vector2>();
    private CharacterType characterType;
    private void Awake()
    {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    public void PlaceBomb(Vector2 position)
    {
        Vector2 cellCenterPos = position.ToCellCenter();
        if (bombPositions.Contains(cellCenterPos)) return;
        bombPositions.Add(cellCenterPos);
        CreateBomb(cellCenterPos);
    }
    public void ThrowBomb(Vector2 destination, float throwSpeed)
    {
        Bomb b = CreateBomb();
        MoveTowardPosition moveTowardPosition = b.gameObject.GetComponent<MoveTowardPosition>();
        Vector2 cellCenterPos = destination.ToCellCenter();
        moveTowardPosition.TargetPosition = cellCenterPos;
        moveTowardPosition.Speed = throwSpeed;
    }
    private Bomb CreateBomb(Vector2 position)
    {
        Bomb b = bombFactory.Get(position).GetComponent<Bomb>();
        b.BombSpawner = this;
        b.Damage = damage;
        b.Lifetime = lifetime;
        b.Length = length;
        b.CharacterType = characterType;
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
