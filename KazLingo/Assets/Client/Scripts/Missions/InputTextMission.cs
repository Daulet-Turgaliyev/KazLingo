using System;
using Client.Scripts.Data;
using Client.Scripts.Missions.DragWordMissionSpace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Missions
{
    public sealed class InputTextMission : AMission
    {
        [SerializeField] private TMP_InputField _inputAnswer;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        private string _trueAnswer;
        
        public override void Initialize(MissionBaseData data)
        {
            base.Initialize(data);
            
            InputTextData inputImage = data as InputTextData;
            if (inputImage != null)
            {
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
        
        public override void ResetMission()
        {
            _inputAnswer.text = string.Empty;
        }
    }
}