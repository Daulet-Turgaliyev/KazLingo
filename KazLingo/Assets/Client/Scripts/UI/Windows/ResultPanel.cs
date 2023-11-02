
    using System;
    using Client.Scripts.Data;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class ResultPanel : BaseWindow
    {
        [SerializeField] private Image _ramaImage;
        [SerializeField] private Image _nextButton;
        
        [SerializeField] private TextMeshProUGUI _labelText;
        [SerializeField] private TextMeshProUGUI _descriptionText;

        [SerializeField] private Color _trueColor;
        [SerializeField] private Color _falseColor;

        public Action onClicked = () => { };
        

        public void SetTrue(MissionBaseData data)
        {
            _canvas.enabled = true;
            _labelText.text = "Супер! Всё верно";
            _descriptionText.text = data.Explanation;
            _nextButton.color = _trueColor;
            _ramaImage.color = _trueColor;
            _labelText.color = _trueColor;
            _descriptionText.color = _trueColor;
        }
        public void SetFalse(MissionBaseData data)
        {
            _canvas.enabled = true;
            _labelText.text = "Упс... Ошибка";
            _descriptionText.text = data.Explanation;
            _nextButton.color = _falseColor;
            _ramaImage.color = _falseColor;
            _labelText.color = _falseColor;
            _descriptionText.color = _falseColor;
        }

        public void Close()
        {
            _canvas.enabled = false;
        }
        public void OnClick()
        {
            onClicked?.Invoke();
        }
    }

