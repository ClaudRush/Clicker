using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private int _clickDamage;

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
                    _board.RemoveEnemy(enemy);
                }
            }
        }
    }
}
