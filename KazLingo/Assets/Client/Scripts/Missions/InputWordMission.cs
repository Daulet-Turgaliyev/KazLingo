using System;
using System.Threading.Tasks;
using Client.Scripts.Data;
using Client.Scripts.Missions.DragWordMissionSpace;
using Google.Cloud.Translation.V2;
using TMPro;
using UnityEngine;

namespace Client.Scripts.Missions
{
    public sealed class InputWordMission : AMission
    {
        [SerializeField] private Transform _questionTransform;
        
        [SerializeField] private QuestionVariant questionVariant;
        
        [SerializeField] private TMP_InputField _inputField;

        private TMP_InputField _currentInputText;

        private string _trueAnswer;
        
        public override void Initialize(MissionBaseData data)
        {
            base.Initialize(data);
            
            InputWordData dragWordData = data as InputWordData;
            if (dragWordData != null)
            {
                SplitQuestionText(dragWordData.QuestionText);
                CreateInputText(dragWordData.InputIndex);
                _trueAnswer = dragWordData.TrueText;
            }
        }        

        private void SplitQuestionText(string inputString)
        {
            string[] words = inputString.Split(' ');
            foreach (string word in words)
            {
                QuestionVariant questionElement = Instantiate(questionVariant, _questionTransform);
                questionElement.Initialize(word);
            }
        }
        
        private async void CreateInputText(int index)
        {
            TMP_InputField questionElement = Instantiate(_inputField, _questionTransform);
            await Task.Delay(500);
            questionElement.transform.SetSiblingIndex(index);
            _currentInputText = questionElement;
        }



        public override bool CheckAnswer()
        {
            if (_currentInputText == null)
            {
                Debug.LogError($"{_currentInputText} is null");
                return false;
            }
            
            string formattedUserInput = NormalizeString(_currentInputText.text);
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
            for (int i = 0; i < _questionTransform.childCount; i++)
            {
                Destroy(_questionTransform.GetChild(i).gameObject);
            }

            Initialize(MissionBaseData);
        }
    }
}