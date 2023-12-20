using Client.Scripts.Data;
using UnityEngine;

namespace Client.Scripts.Missions
{
    public abstract class AMission : MonoBehaviour
    {
        public MissionBaseData MissionBaseData { get; private set; }

        public virtual void Initialize(MissionBaseData data)
        {
            MissionBaseData = data;
        }
        public abstract bool CheckAnswer();
        public abstract void ResetMission();
        
        protected string NormalizeString(string input)
        {
            return input.ToLower().Replace(" ", "");
        }
    }
}