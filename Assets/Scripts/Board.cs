using System;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _enemiesForDefeat;
    private List<Enemy> _enemies = new List<Enemy>();
    public int DeadEnemiesCount { get; private set; } = 0;

    public Action EnemyKill;
    public Action EndGame;

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);
        DeadEnemiesCount++;
        EnemyKill?.Invoke();
    }

    public void RemoveAllEnemy()
    {
        var enemiesList = new List<Enemy>(_enemies);
        foreach (var enemy in enemiesList)
        {
            RemoveEnemy(enemy);
        }
    }

    public int GetEnemiesCount()
    {
        return _enemies.Count;
    }

    public void IsEndGame()
    {
        if (_enemies.Count >= _enemiesForDefeat)
        {
            UpdateHightScore();
            EndGame?.Invoke();
        }
    }
    public void UpdateHightScore()
    {
        if (PlayerPrefs.HasKey("HScore"))
        {
            if (PlayerPrefs.GetInt("HScore") < DeadEnemiesCount)
            {
                PlayerPrefs.SetInt("HScore", DeadEnemiesCount);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HScore", DeadEnemiesCount);
        }
    }
}
