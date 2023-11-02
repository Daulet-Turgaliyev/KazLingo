using Client.Scripts.Missions;
using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "PutTogetherSentenceData", menuName = "Create Mission/PutTogetherSentence Mission", order = 0)]
    public sealed class PutTogetherSentenceData : MissionBaseData
    {
        [field:SerializeField] public PutTogetherSentenceMission PutTogetherSentenceMission { get; private set; }

        [field:SerializeField, TextArea]
        public string TittleText { get; private set; }
        [field:SerializeField, TextArea]
        public string QuestionText { get; private set; }
        [field:SerializeField, TextArea]
        public string TrueAnswer { get; private set; }
        
        private void OnValidate()
        {
            if (PutTogetherSentenceMission == null)
            {
                PutTogetherSentenceMission = Resources.Load<PutTogetherSentenceMission>("MissionPrefabs/PutTogetherSentenceCanvas");
            }
        }
    }
}