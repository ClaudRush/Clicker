using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Text _enemiesCounter;
    [SerializeField] private Text _killedCounter;

    private void Start()
    {
        _enemyFactory.EnemyKill += UpdateAllCounters;
        _enemyFactory.EnemySpawn += UpdateEnemiesCounter;
    }
    private void OnDestroy()
    {
        _enemyFactory.EnemyKill -= UpdateAllCounters;
        _enemyFactory.EnemyKill -= UpdateEnemiesCounter;
    }
    private void UpdateAllCounters()
    {
        _enemiesCounter.text = string.Format("Enemies on board: {0}", _enemyFactory.GetEnemiesCount());
        _killedCounter.text = string.Format("Killed enemies: {0}", _enemyFactory.DeadEnemiesCount);
    }

    private void UpdateEnemiesCounter()
    {
        _enemiesCounter.text = string.Format("Enemies on board: {0}", _enemyFactory.GetEnemiesCount());
    }
}
