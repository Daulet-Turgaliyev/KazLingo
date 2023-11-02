using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "Lesson", menuName = "Create Lesson/New Lesson", order = 0)]

    public class LessonData : ScriptableObject
    {
        [field:SerializeField]
        public string Index { get; private set; }

        [field: SerializeField, ReadOnly]
        public string LessonName { get; private set; }
        
        [field:SerializeField, TextArea]
        public string Tittle { get; private set; }
        [field:SerializeField, TextArea]
        public string Description { get; private set; }
        [field:SerializeField]
        public MissionBaseData[] Missions { get; private set; }

        private void OnValidate()
        {
            LessonName = $"Урок {Index}";
        }
    }
}