using System;
using Flexalon;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client.Scripts.Missions.DragWordMissionSpace
{
    public sealed class VariantButton : MonoBehaviour
    {
        private TextMeshProUGUI _answerText;
        private Transform _targetTransform;
        public string Answer { get; private set; }

        private void Awake()
        {
            _answerText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Initialize(string text, Transform target)
        {
            _answerText.text = text;
            Answer = text;
            _targetTransform = target;
        }

        public void OnClick()
        {
            if (_targetTransform != null)
            {
                transform.SetParent(_targetTransform);
            }
        }
    }
}
