using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    private int _clickDamage = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickOnEnemy();
        }
    }

    public void ClickOnEnemy()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity))
        {
            var enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ApplyDamage(_clickDamage);
                if (enemy.IsDead())
                {
                    _enemyFactory.RemoveEnemy(enemy);
                    _enemyFactory.DeadEnemiesCount++;
                    _enemyFactory.EnemyKill?.Invoke();
                }
                
            }
        }
    }
}
