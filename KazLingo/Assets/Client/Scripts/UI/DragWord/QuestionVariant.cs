using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Client.Scripts.Missions.DragWordMissionSpace
{
    public sealed class QuestionVariant : MonoBehaviour
    {
        private TextMeshProUGUI _answerText;

        public void Initialize(string text)
        {
            _answerText = GetComponentInChildren<TextMeshProUGUI>();
            _answerText.text = text;
        }
    }
}