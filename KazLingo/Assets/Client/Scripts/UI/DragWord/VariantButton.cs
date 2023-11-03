using Client.Scripts.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace Client.Scripts.Missions.DragWordMissionSpace
{
    public sealed class VariantButton : MonoBehaviour
    {
        private TextMeshProUGUI _answerText;
        private Transform _targetTransform;
        public string Answer { get; private set; }

        public void Initialize(string text, Transform target)
        {
            _answerText = GetComponentInChildren<TextMeshProUGUI>();
            _answerText.text = text;
            Answer = text;
            _targetTransform = target;
        }

        public void OnClick()
        {
            AudioController.Instance.PlaySelectVariantSound();
            if (_targetTransform != null)
            {
                transform.SetParent(_targetTransform);
            }
        }
    }
}
