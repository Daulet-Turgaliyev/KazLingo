using System;
using Client.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Missions
{
    public sealed class InputImageMission : AMission
    {
        [SerializeField] private TMP_InputField _inputAnswer;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _iconImage;
        private string _trueAnswer;
        
        public override void Initialize(MissionBaseData data)
        {
            base.Initialize(data);
            
            InputImageData inputImage = data as InputImageData;
            if (inputImage != null)
            {
                _iconImage.sprite = inputImage.Image;
                _trueAnswer = inputImage.TrueText;
                _descriptionText.text = inputImage.Description;
            }
        }        

        public override bool CheckAnswer()
        {
            string formattedUserInput = NormalizeString(_inputAnswer.text);
            string formattedTargetString = NormalizeString(_trueAnswer);

            bool areEqual = formattedUserInput.Equals(formattedTargetString, StringComparison.OrdinalIgnoreCase);

            
            if (areEqual == true)
            {
                return true;
            }

            return false;

        }
        
        private string NormalizeString(string input)
        {
            return input.ToLower().Replace(" ", "");
        }
    }
}