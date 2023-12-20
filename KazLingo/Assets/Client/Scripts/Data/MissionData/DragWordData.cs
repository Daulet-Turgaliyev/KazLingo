using Client.Scripts.Missions;
using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "DragWordMission", menuName = "Create Mission/Drag Mission", order = 0)]
    public sealed class DragWordData : MissionBaseData
    {
        public DragWordMission DragWordMission { get; private set; }

        public string Answer;
        public string[] CorrectOption;
        public int InputIndex;
        public WordInfo QuestionText;
        public WordInfo AnswerText;

        private void OnValidate()
        {
            if (DragWordMission == null)
            {
                DragWordMission = Resources.Load<DragWordMission>("MissionPrefabs/DragWordCanvas");
            }
        }
    }
}