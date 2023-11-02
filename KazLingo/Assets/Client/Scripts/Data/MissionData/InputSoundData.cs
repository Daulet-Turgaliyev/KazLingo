using Client.Scripts.Missions;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "InputSoundData", menuName = "Create Mission/InputSound Mission", order = 0)]
    public sealed class InputSoundData : MissionBaseData
    {
        [field:SerializeField] public InputSoundMission InputSoundMission { get; private set; }
        [field:SerializeField]
        public AudioClip Clip { get; private set; }
        [field:SerializeField, TextArea]
        public string TrueText { get; private set; }
        
        private void OnValidate()
        {
            if (InputSoundMission == null)
            {
                InputSoundMission = Resources.Load<InputSoundMission>("MissionPrefabs/InputSoundCanvas");
            }
        }
    }
}