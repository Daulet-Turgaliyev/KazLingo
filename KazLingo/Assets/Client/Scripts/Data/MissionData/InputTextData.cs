using Client.Scripts.Missions;
using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "InputTextData", menuName = "Create Mission/InputText Mission", order = 0)]
    public class InputTextData : MissionBaseData
    {
        [field:SerializeField] public InputTextMission InputTextMission { get; private set; }

        [field:SerializeField, TextArea]
        public string Description { get; private set; }
        [field:SerializeField, TextArea]
        public string TrueText { get; private set; }
        
        private void OnValidate()
        {
            if (InputTextMission == null)
            {
                InputTextMission = Resources.Load<InputTextMission>("MissionPrefabs/InputTextCanvas");
            }
        }
    }
}