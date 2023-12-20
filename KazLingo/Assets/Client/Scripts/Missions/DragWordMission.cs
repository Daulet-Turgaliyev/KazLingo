using System;
using System.Threading.Tasks;
using Client.Scripts.Data;
using Client.Scripts.Missions.DragWordMissionSpace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Client.Scripts.Missions
{
    public sealed class DragWordMission : AMission
    {
        [SerializeField] private Transform _questionTransform;
        [SerializeField] private Transform _variantTransform;
        
        [SerializeField] private QuestionVariant questionVariant;
        [SerializeField] private VariantButton _variantButton;
        
        [SerializeField] private InteractorQuestion _interactorQuestion;

        private string[] _trueAnswers;
        private InteractorQuestion _currentInteractor;
        
        public override void Initialize(MissionBaseData data)
        {
            base.Initialize(data);
            
            DragWordData dragWordData = data as DragWordData;
            if (dragWordData != null)
            {
                SplitQuestionText(dragWordData.QuestionText);
                SplitVariantText(dragWordData.AnswerText);
                CreateInteractor(dragWordData.InputIndex);
                _trueAnswers = dragWordData.CorrectOption;
            }
        }        

        private void SplitQuestionText(WordInfo words)
        {
            foreach (string word in words.Kazakh)
            {
                QuestionVariant questionElement = Instantiate(questionVariant, _questionTransform);
                questionElement.Initialize(word);
            }
        }
        
        private void SplitVariantText(WordInfo words)
        {
            GameObject[] elements = new GameObject[words.Kazakh.Length];
            for (var i = 0; i < words.Kazakh.Length; i++)
            {
                var word = words.Kazakh[i];
                VariantButton questionElement = Instantiate(_variantButton, _variantTransform);
                questionElement.Initialize(word, _questionTransform);
                elements[i] = questionElement.gameObject;
            }

            foreach (var element in elements)
            {
                element.transform.SetSiblingIndex(Random.Range(0, elements.Length));
            }
        }
        
        private async void CreateInteractor(int index)
        {
            InteractorQuestion questionElement = Instantiate(_interactorQuestion, _questionTransform);
            await Task.Delay(500);
            questionElement.transform.SetSiblingIndex(index);
            _currentInteractor = questionElement;
        }



        public override bool CheckAnswer()
        {
            if (_currentInteractor == null)
            {
                Debug.LogWarning($"{_currentInteractor} is null. Check It");
                return false;
            }

            if (_currentInteractor.GetComponentInChildren<VariantButton>() == null)
            {
                Debug.LogWarning($"{nameof(VariantButton)} is null. Check It");
                return false;
            }
            
            string answer = _currentInteractor.GetComponentInChildren<VariantButton>().Answer;

            string formattedUserInput = NormalizeString(answer);
            
            foreach (var trueAnswer in _trueAnswers)
            {
                string formattedTargetString = NormalizeString(trueAnswer);

                bool areEqual = formattedUserInput.Equals(formattedTargetString, StringComparison.OrdinalIgnoreCase);
            
                if (areEqual == true)
                {
                    return true;
                }
            }

            return false;


        }

        public override void ResetMission()
        {
            for (int i = 0; i < _questionTransform.childCount; i++)
            {
                Destroy(_questionTransform.GetChild(i).gameObject);
            }
            
            for (int i = 0; i < _variantTransform.childCount; i++)
            {
                Destroy(_variantTransform.GetChild(i).gameObject);
            }

            Initialize(MissionBaseData);
        }
    }
}