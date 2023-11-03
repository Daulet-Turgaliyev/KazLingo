using System;
using UnityEngine;

namespace Client.Scripts.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance;
        private AudioSource _audioSource;
        [SerializeField] private AudioClip _trueSound;
        [SerializeField] private AudioClip _falseSound;
        [SerializeField] private AudioClip _gameOverPanelSound;
        [SerializeField] private AudioClip _falsePanelSound;
        [SerializeField] private AudioClip _selectVariantSound;

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayTrueSound()
        {
            _audioSource.PlayOneShot(_trueSound);
        }
        
        public void PlayFalseSound()
        {
            _audioSource.PlayOneShot(_falseSound);
        }
        
        public void PlayGameOverSound()
        {
            _audioSource.PlayOneShot(_gameOverPanelSound);
        }
        public void PlayFalsePanelSound()
        {
            _audioSource.PlayOneShot(_falsePanelSound);
        }
        public void PlaySelectVariantSound()
        {
            _audioSource.PlayOneShot(_selectVariantSound);
        }
    }
}