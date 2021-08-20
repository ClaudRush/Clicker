using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform _board;
    [SerializeField] private List<Enemy> _enemyPrefabList;
    [SerializeField, FloatRangeSlider(1f, 7f)] private FloatRange _speed;
    [SerializeField, FloatRangeSlider(3f, 5f)] private FloatRange _health;
    [SerializeField] private float _delaySpawn;
    
    private List<Enemy> _enemies = new List<Enemy>();
    private float _timerProgress = 0f;

    public int DeadEnemiesCount { get; set; } = 0;

    public System.Action EnemyKill;
    public System.Action EnemySpawn;

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
        Enemy instance = Instantiate(_enemyPrefabList[Random.Range(0, _enemyPrefabList.Count)]);
        instance.Initialize(_speed.RandomValueInRange, (int)_health.RandomValueInRange, _board);
        _enemies.Add(instance);
        EnemySpawn?.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        Destroy(enemy);
    }
    public int GetEnemiesCount()
    {
        return _enemies.Count;
    }
}