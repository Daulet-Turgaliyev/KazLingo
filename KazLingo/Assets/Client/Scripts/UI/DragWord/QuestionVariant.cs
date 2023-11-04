using Google.Cloud.Translation.V2;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client.Scripts.Missions.DragWordMissionSpace
{
    public sealed class QuestionVariant : MonoBehaviour, IPointerClickHandler
    {
        private TextMeshProUGUI _answerText;

        private bool _isTranslated;
        private string _sourceText;
        private string _translatedText;

        public void Initialize(string text)
        {
            _answerText = GetComponentInChildren<TextMeshProUGUI>();
            _answerText.text = text;
            _sourceText = text;
        }

        public void OnTranslateClick()
        {
            if (_isTranslated == true)
            {
                _answerText.text = _sourceText;
                _isTranslated = false;
            }
            else
            {
                Translate();
                _isTranslated = true;
            }
        }
        
        private async void Translate()
        {
            if (string.IsNullOrEmpty(_translatedText))
            {
                TranslationClient client = await TranslationClient.CreateAsync();
                TranslationResult result = await client.TranslateTextAsync(_sourceText, LanguageCodes.Russian, LanguageCodes.Kazakh);
                _translatedText = result.TranslatedText;
                _answerText.text = _translatedText;
            }
            else
            {
                _answerText.text = _translatedText;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnTranslateClick();
        }
    }
}