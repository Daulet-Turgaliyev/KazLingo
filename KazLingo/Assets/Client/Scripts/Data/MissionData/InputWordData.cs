using Client.Scripts.Missions;
using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "InputWordMission", menuName = "Create Mission/InputWord", order = 0)]
    public sealed class InputWordData : MissionBaseData
    {
        [field:SerializeField] public InputWordMission InputWordMission { get; private set; }
        [field:SerializeField, TextArea]
        public string QuestionText { get; private set; }
        [field:SerializeField, TextArea]
        public string TrueText { get; private set; }
        [field:SerializeField]
        public int InputIndex { get; private set; }
        
        private void OnValidate()
        {
            if (InputWordMission == null)
            {
                InputWordMission = Resources.Load<InputWordMission>("MissionPrefabs/InputWordCanvas");
            }
        }
    }
}