using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Text _enemiesCounter;
    [SerializeField] private Text _killedCounter;
    [SerializeField] private Image _freezeTimer;
    [SerializeField] private Image _killAllEnemy;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private UIButtonsSettings _uIButtonsSettings;

    private void Start()
    {
        _board.EndGame += EndGame;
        _board.EnemyKill += UpdateAllCounters;
        _enemyFactory.EnemySpawn += UpdateEnemiesCounter;
    }
    private void OnDestroy()
    {
        _board.EndGame -= EndGame;
        _board.EnemyKill -= UpdateAllCounters;
        _enemyFactory.EnemySpawn -= UpdateEnemiesCounter;
    }
    private void UpdateAllCounters()
    {
        _enemiesCounter.text = string.Format("Enemies on board: {0}", _board.GetEnemiesCount());
        _killedCounter.text = string.Format("Killed enemies: {0}", _board.DeadEnemiesCount);
    }

    private void UpdateEnemiesCounter()
    {
        _enemiesCounter.text = string.Format("Enemies on board: {0}", _board.GetEnemiesCount());
    }

    private void Update()
    {
        if (_freezeTimer.fillAmount <= 1f)
        {
            _freezeTimer.fillAmount += Time.deltaTime * (1 / _uIButtonsSettings.DelayFreezeTimerButton);
        }

        if (_killAllEnemy.fillAmount <= 1f)
        {
            _killAllEnemy.fillAmount += Time.deltaTime * (1 / _uIButtonsSettings.DelayKillAllEnemyButton);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _board.UpdateHightScore();
            MainMenu();
        }
    }
    public void FreezeSpawnTimer()
    {
        if (_freezeTimer.fillAmount >= 1f)
        {
            _enemyFactory.FreezeSpawnTimer(_uIButtonsSettings.FreezeTime);
            _freezeTimer.fillAmount = 0f;
        }
    }
    public void RemoveAllEnemy()
    {
        if (_killAllEnemy.fillAmount >= 1f)
        {
            _board.RemoveAllEnemy();
            _killAllEnemy.fillAmount = 0f;
        }
    }

    public void EndGame()
    {
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
        _defeatPanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
