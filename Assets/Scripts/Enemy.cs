using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private int _health;
    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    public void Initialize(float speed, int health, Transform board)
    {
        _mover.Speed = speed;
        _mover.Board = board;
        _health = health;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
    }

    public bool IsDead()
    {
        return _health <= 0;
    }
}
