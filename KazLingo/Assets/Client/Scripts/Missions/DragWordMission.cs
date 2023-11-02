using Client.Scripts.Data;
using Client.Scripts.Missions.DragWordMissionSpace;
using UnityEngine;

namespace Client.Scripts.Missions
{
    public sealed class DragWordMission : AMission
    {
        [SerializeField] private Transform _questionTransform;
        [SerializeField] private Transform _variantTransform;
        
        [SerializeField] private QuestionVariant questionVariant;
        [SerializeField] private VariantButton _variantButton;
        
        [SerializeField] private InteractorQuestion _interactorQuestion;

        private string _trueAnswer;
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
        
        private void SplitVariantText(string inputString)
        {
            string[] words = inputString.Split(' ');
            GameObject[] elements = new GameObject[words.Length];
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                VariantButton questionElement = Instantiate(_variantButton, _variantTransform);
                questionElement.Initialize(word, _questionTransform);
                elements[i] = questionElement.gameObject;
            }

            foreach (var element in elements)
            {
                element.transform.SetSiblingIndex(Random.Range(0, elements.Length));
            }
        }
        
        private void CreateInteractor(int index)
        {
            InteractorQuestion questionElement = Instantiate(_interactorQuestion, _questionTransform);
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

            string answer = _currentInteractor.GetComponentInChildren<VariantButton>().Answer;
            
            if (answer == _trueAnswer)
            {
                return true;
            }

            return false;


        }
    }
}