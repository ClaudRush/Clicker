using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private const float CLAMP_DISTANCE = 0.2f;

    private Vector3 _nextPosition;

    private Transform _board;//Стоит убрать если есть свойтва? 
    private float _speed;//

    public float Speed 
    {
        get { return _speed; } 
        set { _speed = value > 0 ? _speed = value : throw new System.ArgumentOutOfRangeException(); }
    }

    public Transform Board 
    {
        get { return _board; } 
        set { _board = value; }
    }

    private void Start()
    {
        transform.localPosition = GetRandomPosition();
        transform.parent = _board;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, Time.deltaTime *_speed);

        if (Vector3.Distance(transform.position, _nextPosition) < CLAMP_DISTANCE)
        {
            _nextPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        var boardScale = _board.transform.localScale;
        var positionX = Random.Range(-(boardScale.x / 2), boardScale.x / 2) + _board.transform.position.x;
        var positionY = Random.Range(-(boardScale.y / 2), boardScale.y / 2) + _board.transform.position.z;
        return new Vector3(positionX, 0f, positionY);
    }
}
