using System;
using System.Linq;
using Client.Scripts.Data;
using Client.Scripts.Missions.DragWordMissionSpace;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Client.Scripts.Missions
{
    public sealed class PutTogetherSentenceMission : AMission
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private Transform _questionTransform;
        [SerializeField] private Transform _variantTransform;
        
        [SerializeField] private VariantButton _variantButton;
        
        private string _trueAnswer;
        
        public override void Initialize(MissionBaseData data)
        {
            base.Initialize(data);
            
            PutTogetherSentenceData dragWordData = data as PutTogetherSentenceData;
            if (dragWordData != null)
            {
                _titleText.text = dragWordData.TittleText;
                SplitVariantText(dragWordData.QuestionText);
                _trueAnswer = dragWordData.TrueAnswer;
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

        public override bool CheckAnswer()
        {
            VariantButton[] variantButtons = _questionTransform.GetComponentsInChildren<VariantButton>();

            string answer = variantButtons.Aggregate("", (current, btn) => current + btn.Answer);

            string formattedUserInput = NormalizeString(answer);
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
            
            for (int i = 0; i < _variantTransform.childCount; i++)
            {
                Destroy(_variantTransform.GetChild(i).gameObject);
            }

            Initialize(MissionBaseData);
        }
    }
}