using System;
using Client.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Client.Scripts.Missions
{
    public sealed class InputSoundMission : AMission
    {
        [SerializeField] private TMP_InputField _inputAnswer;

        private AudioSource _audioSource;
        private string _trueAnswer;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public override void Initialize(MissionBaseData data)
        {
            base.Initialize(data);
            
            InputSoundData inputImage = data as InputSoundData;
            if (inputImage != null)
            {
                _audioSource.clip = inputImage.Clip;
                _trueAnswer = inputImage.TrueText;
            }
        }

        public void PlaySound()
        {
            if (_audioSource.isPlaying == true)
            {
                _audioSource.Stop();
            }
            _audioSource.Play();
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