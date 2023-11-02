using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Client.Scripts.Missions.DragWordMissionSpace
{
    public sealed class QuestionVariant : MonoBehaviour
    {
        private TextMeshProUGUI _answerText;
        
        private void Awake()
        {
            _answerText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Initialize(string text)
        {
            _answerText.text = text;
        }
    }
}