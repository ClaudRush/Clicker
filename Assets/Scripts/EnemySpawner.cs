using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : GameObjectFactory
{
    [SerializeField] private Transform _board;
    [SerializeField] private List<Enemy> _prefabList;
    [SerializeField, FloatRangeSlider(1f, 7f)] private FloatRange _speed;
    [SerializeField, FloatRangeSlider(3f, 5f)] private FloatRange _health;
    [SerializeField] private float _delaySpawn;

    private float _timerProgress = 0f;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        _timerProgress += Time.deltaTime;
        if (_timerProgress >= _delaySpawn)
        {
            SpawnEnemy();
            _timerProgress = 0;
        }
    }

    public void SpawnEnemy()
    {
        Enemy instance = CreateGameObgectInstance(_prefabList[Random.Range(0, _prefabList.Count)]);
        instance.Initialize(_speed.RandomValueInRange, (int)_health.RandomValueInRange, _board);
    }
}