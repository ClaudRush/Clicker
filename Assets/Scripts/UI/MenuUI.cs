using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private Text _hightScore;

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void HightScore()
    {
        HideAllPanels();
        if (PlayerPrefs.HasKey("HScore"))
        {
            _hightScore.text = PlayerPrefs.GetInt("HScore").ToString();
        }
        _scorePanel.SetActive(true);
    }

    public void Credits()
    {
        HideAllPanels();
        _creditsPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        HideAllPanels();
        _mainPanel.SetActive(true);
    }

    private void HideAllPanels()
    {
        _mainPanel.SetActive(false);
        _scorePanel.SetActive(false);
        _creditsPanel.SetActive(false);
    }
}
