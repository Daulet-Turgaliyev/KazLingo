using Client.Scripts.GameStats;
using TMPro;
using UnityEngine;

public class StartGameWindow : BaseWindow
{
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _missionsText;

        private GameStats _gameStats;
        private int _missionCount;

        public void Initialize(GameStats gameStats, string tittle, string description, int missionCount)
        {
                _titleText.text = tittle;
                _descriptionText.text = description;
                _missionsText.text = $"В данном уроке:\n{missionCount} упражнений";
                _missionCount = missionCount;
                _gameStats = gameStats;
        }
        
        public void StartGame()
        {
                _gameStats.Initialize(Time.time, _missionCount);
                Destroy(gameObject);
        }
}
