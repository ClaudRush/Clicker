using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private List<Enemy> _enemyPrefabList;

    [SerializeField, FloatRangeSlider(1f, 7f)] private FloatRange _speed;
    [SerializeField, FloatRangeSlider(3f, 5f)] private FloatRange _health;

    [SerializeField] private float _delaySpawn;

    private float _timerProgress = 0f;

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

    public void FreezeSpawnTimer(float time)
    {
        _timerProgress -= time;
    }

    public void SpawnEnemy()
    {
        Enemy instance = Instantiate(_enemyPrefabList[Random.Range(0, _enemyPrefabList.Count)]);
        instance.Initialize(_speed.RandomValueInRange, (int)_health.RandomValueInRange, _board.transform);
        _board.AddEnemy(instance);
        _board.IsEndGame();
        EnemySpawn?.Invoke();
    }

}