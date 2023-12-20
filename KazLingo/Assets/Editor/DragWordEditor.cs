using System;
using System.Collections.Generic;
using System.Linq;
using Client.Scripts.Data;
using Client.Scripts.Missions;
using Google.Cloud.Translation.V2;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class DragWordEditor: SerializedScriptableObject
    {
        [LabelText("Level"), Required]
        public int level;
        
        [LabelText("FileName"), Required]
        public string fileName;
        
        [Space(20)]
        [LabelText("InputIndex"), Required]
        public int InputIndex;
        
        [Space(20)]
        [LabelText("Points"), Required]
        public int Points;
        
        [Space(20)]
        [LabelText("Explanation"), TextArea, Required]
        public string Explanation;
        
        [Space(20)]
        [LabelText("Answer"), TextArea, Required]
        public string Answer;
        
        [Space(20)]
        [LabelText("CorrectOption"), TextArea, Required]
        public string[] CorrectOption;
        
        [Space(20)]
        [LabelText("QuestionText"), TextArea, Required]
        public string QuestionText;
        
        [DictionaryDrawerSettings(KeyLabel = "Kazakh", ValueLabel = "Russian")]
        public Dictionary<string, string> SplitQuestion;
        
        [Space(20)]
        [LabelText("AnswerText"), TextArea, Required]
        public string AnswerText;
        
        [DictionaryDrawerSettings(KeyLabel = "Kazakh", ValueLabel = "Russian")]
        public Dictionary<string, string> SplitAnswer;
        

        [Button("Split", ButtonSizes.Large)]
        public void Split()
        {
            TranslationClient client = TranslationClient.Create();
            
            var questionWords = QuestionText.Split(' ');
            
            //TranslationResult result = client.TranslateText(questionWords[i], LanguageCodes.Russian, LanguageCodes.Kazakh);
            
            SplitQuestion = new Dictionary<string, string>();

            foreach (var words in questionWords)
            {
                SplitQuestion.Add(words, "");
            }

            var answerWords = AnswerText.Split(' ');
            SplitAnswer = new Dictionary<string, string>();
            foreach (var words in answerWords)
            {
                SplitAnswer.Add(words, "");
            }

        }

        [Button("Create", ButtonSizes.Large)]
        public void CreateNewMyScriptableObject()
        {
            var instance = ScriptableObject.CreateInstance<DragWordData>();

            instance.Explanation = Explanation;
            instance.Points = Points;
            instance.InputIndex = InputIndex;
            instance.Answer = Answer;
            instance.CorrectOption = CorrectOption;

            instance.QuestionText = new WordInfo(SplitQuestion.Keys.ToArray(), SplitQuestion.Values.ToArray());
            instance.AnswerText = new WordInfo(SplitAnswer.Keys.ToArray(), SplitAnswer.Values.ToArray());
            
            
            if (AssetDatabase.IsValidFolder($"Assets/Client/Data/Level {level}") == false)
            {
                AssetDatabase.CreateFolder("Assets/Client/Data", $"Level {level}");
            }

            AssetDatabase.CreateAsset(instance, $"Assets/Client/Data/Level {level}/{fileName}.asset");

            // Import the object, so it is recognised as a new asset.
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(instance));
        }

    }
}