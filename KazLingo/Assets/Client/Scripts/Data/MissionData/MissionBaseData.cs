using UnityEngine;

namespace Client.Scripts.Data
{
    public class MissionBaseData : ScriptableObject
    {
        [field:SerializeField, TextArea]
        public string Points { get; private set; }
        [field:SerializeField, TextArea]
        public string Explanation { get; private set; }
    }
}