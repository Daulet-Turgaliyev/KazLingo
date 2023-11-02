

using TMPro;
using UnityEngine;

public class StartGameWindow : BaseWindow
{
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _missionsText;


        public void Initialize(string tittle, string description, int missionCount)
        {
                _titleText.text = tittle;
                _descriptionText.text = description;
                _missionsText.text = $"В данном задании: {missionCount} заданий";
        }
        
        public void StartGame()
        {
                Destroy(gameObject);
        }
}
