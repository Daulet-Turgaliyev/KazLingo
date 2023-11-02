using Client.Scripts.Missions;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "InputImageData", menuName = "Create Mission/InputImage Mission", order = 0)]
    public sealed class InputImageData : MissionBaseData
    {
        [field:SerializeField] public InputImageMission InputImageMission { get; private set; }
        [field:SerializeField]
        public Sprite Image { get; private set; }
        [field:SerializeField, TextArea]
        public string Description { get; private set; }
        [field:SerializeField, TextArea]
        public string TrueText { get; private set; }
        
        private void OnValidate()
        {
            if (InputImageMission == null)
            {
                InputImageMission = Resources.Load<InputImageMission>("MissionPrefabs/InputImageCanvas");
            }
        }
    }
}