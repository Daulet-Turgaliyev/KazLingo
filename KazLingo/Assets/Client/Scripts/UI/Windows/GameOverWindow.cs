using Client.Scripts.GameStats;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindow : BaseWindow
{
     private GameStats _gameStats;
     [SerializeField] private TextMeshProUGUI _pointsText;
     [SerializeField] private TextMeshProUGUI _accuracyText;
     [SerializeField] private TextMeshProUGUI _timeText;
     [SerializeField] private TextMeshProUGUI _commentsText;

    public void Initialize(GameStats gameStats)
    {
        _gameStats = gameStats;
    }
    
    private void Start()
    {
        _pointsText.text = $"изумруды: {_gameStats.GetResult().Points}";
        _accuracyText.text = $"точность: {_gameStats.GetResult().Accuracy}";
        _timeText.text = $"время: {_gameStats.GetResult().Time}";

        if (_gameStats.GetResult().AccuracyFloat > 90)
        {
            _commentsText.text = "Вау! Супер результат. Так держать";
        }
        else if (_gameStats.GetResult().AccuracyFloat > 60)
        {
            _commentsText.text = "Неплохо. Продолжай работать и у тебя всё получится";
        }
        else
        {
            _commentsText.text = "Не расстраивайся! Ты неплохо поработал";
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
