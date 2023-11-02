using System;
using Client.Scripts.Missions;
using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "DragWordMission", menuName = "Create Mission/Drag Mission", order = 0)]
    public sealed class DragWordData : MissionBaseData
    {
        [field:SerializeField] public DragWordMission DragWordMission { get; private set; }

        [field:SerializeField, TextArea]
        public string QuestionText { get; private set; }
        [field:SerializeField, TextArea]
        public string AnswerText { get; private set; }
        [field:SerializeField, TextArea]
        public string TrueText { get; private set; }
        [field:SerializeField]
        public int InputIndex { get; private set; }

        private void OnValidate()
        {
            if (DragWordMission == null)
            {
                DragWordMission = Resources.Load<DragWordMission>("MissionPrefabs/DragWordCanvas");
            }
        }
    }
}