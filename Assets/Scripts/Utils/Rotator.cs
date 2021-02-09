using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private enum Direction
    {
        Clockwise = -1,
        AntiClockwise = 1,
    }
    [SerializeField] private Direction direction = Direction.Clockwise;
    [SerializeField] private float rotateSpeed = 5;
    private int multiplier;
    private void Start()
    {
        multiplier = (int)direction;
    }
    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * multiplier * Time.deltaTime);
    }
}
